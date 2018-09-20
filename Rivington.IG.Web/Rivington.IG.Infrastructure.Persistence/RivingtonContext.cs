using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Infrastructure.Security;
using Rivington.IG.Domain.Models;
using Microsoft.AspNetCore.Http;
using Rivington.IG.Domain.Models.Views;
using EntityFrameworkCore.Triggers;
using Rivington.IG.Domain.Models.InspectionOrderLog;
using Rivington.IG.Domain.Models.Dashboard;

namespace Rivington.IG.Infrastructure.Persistence
{
    public partial class RivingtonContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
            ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, 
        IRivingtonContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RivingtonContext(DbContextOptions<RivingtonContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #region Saving
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return this.SaveChangesWithTriggers(base.SaveChanges);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess, cancellationToken: cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
        }


        /// <summary>
        /// https://www.codeproject.com/Tips/1178139/Implementing-Common-Audit-Fields-with-EF-Core-s-Sh
        /// https://www.meziantou.net/2017/07/03/entity-framework-core-generate-tracking-columns
        /// </summary>
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.LastUpdatedAt = now;
                            trackable.LastUpdatedBy = user;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.CreatedBy = user;
                            trackable.LastUpdatedAt = now;
                            trackable.LastUpdatedBy = user;
                            break;
                    }
                }
            }
        }

        public Guid GetCurrentUser()
        {
            // If it returns null, even when the user was authenticated, you may try to get the value of a specific claim 
            var authenticatedUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var authenticatedUser = Guid.Empty;
            if (authenticatedUserId != null) 
            {
                authenticatedUser = new Guid(authenticatedUserId);
            }
            else
            {
                authenticatedUser = Guid.Empty;
            }

            return authenticatedUser; // "SYSTEM"; // TODO implement your own logic

            // If you are using ASP.NET Core, you should look at this answer on StackOverflow
            // https://stackoverflow.com/a/48554738/2996339
        }
        #endregion Saving

        //View
        public DbSet<InspectionOrderView> InspectionOrderView { get; set; }
        public DbSet<ApplicationUserView> ApplicationUserView { get; set; }
        public DbSet<InspectionOrderNotesView> InspectionOrderNotesView { get; set; }
        public DbSet<InspectionStatusGroupingsView> InspectionStatusGroupingsView { get; set; }
        public DbSet<MitigationStatusCountView> MitigationStatusCountView { get; set; }

        public DbSet<InspectionOrderNote> InspectionOrderNotes { get; set; }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<ForgotPassword> ForgotPassword { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<InspectionOrder> InspectionOrder { get; set; }
        public DbSet<MitigationStatus> MitigationStatus { get; set; }
        public DbSet<PropertyValue> PropertyValue { get; set; }
        public DbSet<InspectionStatus> InspectionStatus { get; set; }
        public DbSet<ApplicationRole> Role { get; set; }
        public DbSet<InspectionOrderPropertyPhotoPhotos> InspectionOrderPropertyPhotoPhotos { get; set; }
        public DbSet<InspectionOrderPropertyPhoto> InspectionOrderPropertyPhoto { get; set; }
        public DbSet<InspectionOrderLogs> InspectionOrderLogs { get; set; }
        public DbSet<StaticContent> StaticContent { get; set; }
        public DbSet<ThirdPartyXML> ThirdPartyXML { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildIdentity(modelBuilder);

            Domain.Models.OrderManagement.InspectionOrder.BuildModel(modelBuilder);
            
            
            modelBuilder.Entity<City>().HasOne(c => c.State);
            modelBuilder.Entity<City>().ToTable(nameof(City));

            modelBuilder.Entity<ForgotPassword>().ToTable(nameof(ForgotPassword));

            Image.BuildModel(modelBuilder);

            Domain.Models.StaticContent.BuildModel(modelBuilder);
        }

        private static void BuildIdentity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Tokens).WithOne(i => i.User);
            modelBuilder.Entity<ApplicationRole>().ToTable("Role");

            modelBuilder.Entity<ApplicationRoleClaim>().ToTable("RoleClaim");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRole");
            modelBuilder.Entity<ApplicationUserToken>().ToTable("UserToken");

            modelBuilder.Entity<Token>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Token>().ToTable(nameof(Token));

            modelBuilder.Entity<Token>().HasOne(i => i.User).WithMany(u => u.Tokens);
        }
    }
}