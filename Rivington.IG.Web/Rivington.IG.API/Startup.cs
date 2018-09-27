using System;
using System.IO;
using System.ServiceModel;
using System.Text;
using ElmahCore;
using ImageMagick;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Rivington.IG.API.Authorization;
using Rivington.IG.API.Controllers;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Account;
using Rivington.IG.Domain.Dashboard;
using Rivington.IG.Domain.InspectionNotes;
using Rivington.IG.Domain.InspectionOrderLog;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation.ChildMitigation;
using Rivington.IG.Domain.Pdf;
using Rivington.IG.Domain.StaticPages;
using Rivington.IG.Domain.ThirdPartyPolicy;
using Rivington.IG.Infrastructure;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Persistence.Repositories;
using Rivington.IG.Infrastructure.Security;
using SoapCore;
using Swashbuckle.AspNetCore.Swagger;
using IPolicyService = Rivington.IG.API.Controllers.IPolicyService;

namespace Rivington.IG.API
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddEntityFrameworkSqlServer();

			services.AddDbContext<RivingtonContext>(
				options => options.UseSqlServer(AppSettings.DefaultConnectionString)
			);

			#region Security

			services
				.AddIdentity<ApplicationUser, ApplicationRole>(options =>
				{
					options.Password.RequireDigit = true;
					options.Password.RequiredLength = 8;
					options.Password.RequireLowercase = true;
					options.Password.RequireUppercase = true;

					// Lockout settings
					options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
					options.Lockout.MaxFailedAccessAttempts = 5;
					options.Lockout.AllowedForNewUsers = true;

					// Signin settings
					options.SignIn.RequireConfirmedEmail = false;
					options.SignIn.RequireConfirmedPhoneNumber = false;

					// User settings
					options.User.RequireUniqueEmail = true;
				})
				.AddEntityFrameworkStores<RivingtonContext>()
				.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = "RivingtonCookie";
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
				options.LoginPath = "/Account/Login";
				options.LogoutPath = "/Account/Logout";
				options.AccessDeniedPath = "/Account/Forbidden";
				options.SlidingExpiration = true;
				options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
			});

			#endregion

			#region Authentication

			{
				var authSetting = Domain.CustomCodes.AppSettings.AuthJwt;

				services
					.AddAuthentication(opts =>
					{
						opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
						opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					})
					.AddJwtBearer(cfg =>
					{
						cfg.TokenValidationParameters = new TokenValidationParameters
						{
							// standard configuration
							ValidIssuer = authSetting["Issuer"],
							ValidAudience = authSetting["Audience"],
							IssuerSigningKey = new SymmetricSecurityKey(
								Encoding.UTF8.GetBytes(authSetting["Key"])),
							ClockSkew = TimeSpan.Zero,
							// security switches
							RequireExpirationTime = true,
							ValidateIssuer = true,
							ValidateIssuerSigningKey = true,
							ValidateAudience = true
						};

						// todo change to true if prod environment will use https
						cfg.RequireHttpsMetadata = false;

						cfg.SaveToken = true;
						cfg.ClaimsIssuer = cfg.TokenValidationParameters.ValidIssuer;
					});

				// api user claim policy
				services.AddAuthorization(options =>
				{
					options.AddPolicy(PolicyNames.SystemOnly,
						policy => policy.RequireRole(Roles.System));
					options.AddPolicy(PolicyNames.AdministratorsOnly,
						policy => policy.RequireRole(Roles.Administrator));
					options.AddPolicy(PolicyNames.UnderWritersOnly,
						policy => policy.RequireRole(Roles.UnderWriter));
					options.AddPolicy(PolicyNames.InspectorManagersOnly,
						policy => policy.RequireRole(Roles.InspectorManager));
					options.AddPolicy(PolicyNames.InspectorsOnly,
						policy => policy.RequireRole(Roles.Inspector));

					options.AddPolicy(PolicyNames.Anyone,
						policy => policy.RequireRole(
							Roles.System, Roles.Administrator, Roles.UnderWriter, Roles.InspectorManager, Roles.Inspector, Roles.Insured)
					);

					options.AddPolicy(PolicyNames.AnyoneExceptInsured,
						policy => policy.RequireRole(
							Roles.System, Roles.Administrator, Roles.UnderWriter, Roles.InspectorManager, Roles.Inspector, Roles.Insured)
					);

					options.AddPolicy(PolicyNames.AccessCreateIO,
						policy => policy.RequireRole(
							Roles.System, Roles.Administrator, Roles.UnderWriter, Roles.InspectorManager, Roles.Inspector, Roles.Insured)
					);

					options.AddPolicy(PolicyNames.ModifyIO,
						policy => policy.RequireRole(
							Roles.System, Roles.Administrator, Roles.UnderWriter, Roles.InspectorManager, Roles.Inspector, Roles.Insured)
					);

					options.AddPolicy(PolicyNames.AccessUserManagement,
						policy => policy.RequireRole(
							Roles.System, Roles.Administrator, Roles.UnderWriter, Roles.InspectorManager, Roles.Inspector, Roles.Insured)
					);

					//options.AddPolicy(
					//    "CanAccessVIPArea",
					//    policyBuilder => policyBuilder.RequireAssertion(
					//        context => context.User.HasClaim(claim => 
					//                       claim.Type == "VIPNumber" 
					//                       || claim.Type == "EmployeeNumber")
					//                   || context.User.IsInRole("CEO"))
					//);
				});
			}

			#endregion

			AddDependencyInjection(services);

			#region Swagger

			services.AddSwaggerGen(swag =>
			{
				var swaggerSettings = AppSettings.Configuration.GetSection("Swagger");

				swag.SwaggerDoc(swaggerSettings["Doc:Name"], new Info { Title = swaggerSettings["Doc:Title"] });
				swag.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}Rivington.IG.API.xml");
			});


			services.AddCors(config =>
			{
				config.AddPolicy(Domain.CustomCodes.AppSettings.CorsName, policy =>
				{
					policy.AllowAnyMethod();
					policy.AllowAnyHeader();
					policy.AllowAnyOrigin();
					policy.AllowCredentials();
					//policy.WithOrigins("http://localhost:4200", "http://localhost:4200/");
				});
			});

			#endregion

			#region Elmah

			///https://github.com/ElmahCore/ElmahCore
			services.AddElmah<SqlErrorLog>(options =>
			{
				options.Path = AppSettings.Configuration["Logging:Elmah:Path"];
				options.ConnectionString = AppSettings.Configuration.GetConnectionString("Elmah");
			});

			#endregion

			services.AddMemoryCache();

			services.AddMvc(config =>
			{
				config.ModelBinderProviders.Insert(0, new IOModelBinderProvider<InspectionOrder>());
				config.ModelBinderProviders.Insert(1, new IOModelBinderProvider<ApplicationUser>());
			})
				.AddJsonOptions(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

			// https://www.lynda.com/ASP-NET-tutorials/Response-caching-compression/656815/701127-4.html
			// see sample usage in KeyValueController
			services.AddResponseCaching(options =>
			{
				//options.MaximumBodySize = 1024;
				//options.UseCaseSensitivePaths = true;
			});
		}

		private void AddDependencyInjection(IServiceCollection services)
		{
			services.AddScoped<IRivingtonContext, RivingtonContext>();

			services.AddScoped<IDashboardRepository, DashboardRepository>();

			services.AddTransient<IInspectionOrderService, InspectionOrderService>();
			services.AddScoped<IInspectionOrderRepository, InspectionOrderRepository>();

			services.AddTransient<IInspectionOrderNotesService, InspectionOrderNotesService>();
			services.AddScoped<IInspectionOrderNotesRepository, InspectionOrderNotesRepository>();

			services.AddScoped<ICityRepository, CityRepository>();
			services.AddScoped<IStateRepository, StateRepository>();

			services.AddTransient<IAccountUserRoleRepository, AccountUserRoleRepository>();
			services.AddTransient<IAccountRoleRepository, AccountRoleRepository>();
			services.AddTransient<IAccountRepository, AccountRepository>();
			services.AddScoped<IAccountcontrollerService, AccountControllerService>();

			services.AddTransient<IForgotPasswordRepository, ForgotPasswordRepository>();
			services.AddScoped<IForgotPasswordService, ForgotPasswordService>();

			services.AddScoped<IMitigationStatusRepository, MitigationStatusRepository>();
			services.AddScoped<IInspectionStatusRepository, InspectionStatusRepository>();
			services.AddScoped<IPropertyValueRepository, PropertyValueRepository>();
			services.AddScoped<IPolicyRepository, PolicyRepository>();
			services.AddScoped<IPhotoTypeRepository, PhotoTypeRepository>();
			services.AddScoped<IPhotoTypeGroupRepository, PhotoTypeGroupRepository>();

			services.AddScoped<IInspectionOrderPropertyPhotoRepository, InspectionOrderPropertyPhotoRepository>();
			services.AddScoped<IInspectionOrderPropertyPhotoPhotosRepository, InspectionOrderPropertyPhotoPhotosRepository>();

			services
				.AddScoped<IInspectionOrderWildfireAssessmentMitigationRepository,
					InspectionOrderWildfireAssessmentMitigationRepository>();
			services
				.AddScoped<IInspectionOrderWildfireAssessmentMitigationRecommendationsRepository,
					InspectionOrderWildfireAssessmentMitigationRecommendationsRepository>();
			services
				.AddScoped<IInspectionOrderWildfireAssessmentMitigationRequirementsRepository,
					InspectionOrderWildfireAssessmentMitigationRequirementsRepository>();


			services
				.AddScoped<IInspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository,
					InspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository>();
			services
				.AddScoped<IInspectionOrderWildfireAssessmentChildMitigationRequirementsRepository,
					InspectionOrderWildfireAssessmentChildMitigationRequirementsRepository>();

			services
				.AddScoped<IInspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository,
					InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository>();
			services
				.AddScoped<IInspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository,
					InspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository>();
			services
				.AddScoped<IInspectionOrderPropertyNonWildfireAssessmentMitigationRepository,
					InspectionOrderPropertyNonWildfireAssessmentMitigationRepository>();

			services
				.AddScoped<IInspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository,
					InspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository>();
			services
				.AddScoped<IInspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository,
					InspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository>();

			services.AddTransient<IMapService, MapService>();

			services.AddTransient<IUtilityService, UtilityService>();
			services.AddScoped<IUtilityRepository, UtilityRepository>();

			services.AddScoped<IKeyValueRepository, KeyValueRepository>();

			services.AddTransient<ICacheService, CacheService>();

			services.AddTransient<IImageService, ImageService>();
			services.AddScoped<IImageRepository, ImageRepository>();

			services.AddScoped<IInspectionOrderMitigationRepository, InspectionOrderMitigationRepository>();

			services.AddScoped<InspectionOrderMitigationController>();

			services.AddScoped<IInspectionOrderLog, InspectionOrderLogRepository>();

			services.AddScoped<IWkHtmlToPdfService, WkHtmlToPdfService>();

			services.AddScoped<IStaticContentRepository, StaticContentRepository>();

			services.AddScoped<CompressContentAttribute>();

			services.AddScoped<IPolicyService, PolicyController>();

			services.AddScoped<IThirdPartyRepository, ThirdPartyPolicyRepository>();

			services.AddScoped<IEnumerationRepository, EnumerationRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

			app.UseCors(Domain.CustomCodes.AppSettings.CorsName);

			var swaggerSettings = AppSettings.Configuration.GetSection("Swagger");
			if (!env.IsProduction())
			{
				app.UseSwagger();
				app.UseSwaggerUI(swag =>
				{
					swag.SwaggerEndpoint(swaggerSettings["EndPoint:Url"], swaggerSettings["EndPoint:Description"]);
				});
			}

			app.UseAngularRouting();

			app.UseCdnHandler();

			app.UseResponseCaching();
			
			app.UseResponseCompression();

			// For the /wwwroot folder
			app.UseStaticFiles();

			// For the /StaticFiles folder
			var staticfilesPath = Domain.CustomCodes.AppSettings.Paths.StaticFiles;
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), staticfilesPath)),
				RequestPath = $"/{staticfilesPath}"
			});

			app.UseFileServer(new FileServerOptions
			{
				FileProvider = new PhysicalFileProvider(Domain.CustomCodes.AppSettings.Paths.FileServerPhysical),
				RequestPath = new PathString(@"/cdn"),
				EnableDirectoryBrowsing = false
			});

			MagickAnyCPU.CacheDirectory = Domain.CustomCodes.AppSettings.Paths.FileServerPhysical;

			app.UseDefaultFiles();

			app.UseAuthentication();

			app.UseElmah();

			app.UseErrorLogging();

			app.UseMvc();

			app.UseSoapEndpoint<IPolicyService>("/PolicyController.svc", new BasicHttpBinding(), SoapSerializer.DataContractSerializer);
			app.UseSoapEndpoint<IPolicyService>("/PolicyController.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);
		}
	}
}
