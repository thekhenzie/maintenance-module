USE [InspectorGadget]
GO
INSERT [dbo].[User] 
([Id], 
	[AccessFailedCount], 
		[ConcurrencyStamp], 
			[CreatedDate], 
				[DisplayName], 
					[Email], 
						[EmailConfirmed], [FirstName], 
								[LastModifiedDate], 
									[LastName], [LockoutEnabled], [LockoutEnd], 
										[NormalizedEmail], 
											[NormalizedUserName], 
												[PasswordHash], 
													[PhoneNumber], [PhoneNumberConfirmed], 
														[SecurityStamp], 
															[TwoFactorEnabled], 
																[UserName], 
																	[MiddleName], [ProfilePhoto], [City], [MobileNumber], [State], [StreetAddress1], [StreetAddress2], [ZipCode], [ProfilePhotoId]) 
VALUES (
N'cd26ce2c-a04e-4a01-2e89-08d5f825e20c', 
	0, 
		N'019403b3-8e9a-4001-a2ae-af4d3ee01131', 
			CAST(N'2018-08-02T11:13:12.6859855' AS DateTime2), 
				NULL, 
					N'igsystem@mailinator.com', 
						1, NULL, 
								CAST(N'2018-08-02T11:13:12.6859855' AS DateTime2), 
									NULL, 1, NULL, 
										N'IGSYSTEM@MAILINATOR.COM', 
											N'SYSTEM', 
												N'AQAAAAEAACcQAAAAEB4HB03O6wk2ArKYFW3dzAbpJ0/ZXcX2hI6+DVLzJT5GRLyfM4gHEIZOipg+tQn2Zg==', 
													NULL, 0, 
														N'e24650e6-cef4-46ba-8259-2f63669e9c54', 
															0, 
																N'SYSTEM', 
																	NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)




INSERT [dbo].[User] ([Id], [AccessFailedCount], [ConcurrencyStamp], [CreatedDate], [DisplayName], [Email], [EmailConfirmed], [FirstName], [LastModifiedDate], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [MiddleName], [ProfilePhoto], [City], [MobileNumber], [State], [StreetAddress1], [StreetAddress2], [ZipCode], [ProfilePhotoId]) VALUES (N'f4b3d117-8a51-4dac-2e8a-08d5f825e20c', 0, N'fb1170a4-278f-4f7d-840f-566ccf1fc522', CAST(N'2018-08-02T11:13:14.3662984' AS DateTime2), NULL, N'igadministrator@mailinator.com', 1, NULL, CAST(N'2018-08-02T11:13:14.3662984' AS DateTime2), NULL, 1, NULL, N'IGADMINISTRATOR@MAILINATOR.COM', N'ADMINISTRATOR_USER', N'AQAAAAEAACcQAAAAEO9tpiA0gfYHbsL29gskn5Mub5Kk0wfDt5AWl2blT/pOmglzEoyYR0sfa6YFDDcrSw==', NULL, 0, N'22c432a7-a24e-460f-acd4-cccb373025a0', 0, N'administrator_user', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [AccessFailedCount], [ConcurrencyStamp], [CreatedDate], [DisplayName], [Email], [EmailConfirmed], [FirstName], [LastModifiedDate], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [MiddleName], [ProfilePhoto], [City], [MobileNumber], [State], [StreetAddress1], [StreetAddress2], [ZipCode], [ProfilePhotoId]) VALUES (N'd84367e7-3e5d-4179-2e8b-08d5f825e20c', 0, N'2ca7e429-1f0e-464a-8586-d1dc89b8bc00', CAST(N'2018-08-02T11:13:14.3662984' AS DateTime2), NULL, N'igunderwriter@mailinator.com', 1, NULL, CAST(N'2018-08-02T11:13:14.3662984' AS DateTime2), NULL, 1, NULL, N'IGUNDERWRITER@MAILINATOR.COM', N'UNDERWRITER_USER', N'AQAAAAEAACcQAAAAEMjzsVRtuH2TwzYR+ueRrBOQL+DBsC7Mhg32qR/Mp9evoQU+12dNgAl1b5tJbWFr6A==', NULL, 0, N'c53ff983-94d3-4ebc-b2c9-324ff4716c5d', 0, N'underwriter_user', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [AccessFailedCount], [ConcurrencyStamp], [CreatedDate], [DisplayName], [Email], [EmailConfirmed], [FirstName], [LastModifiedDate], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [MiddleName], [ProfilePhoto], [City], [MobileNumber], [State], [StreetAddress1], [StreetAddress2], [ZipCode], [ProfilePhotoId]) VALUES (N'e0104a41-f117-41b3-2e8c-08d5f825e20c', 0, N'4e9b4be6-5aec-4594-9db0-e619a27c509f', CAST(N'2018-08-02T11:13:14.3662984' AS DateTime2), NULL, N'iginspectormanager@mailinator.com', 1, NULL, CAST(N'2018-08-02T11:13:14.3662984' AS DateTime2), NULL, 1, NULL, N'IGINSPECTORMANAGER@MAILINATOR.COM', N'INSPECTORMANAGER_USER', N'AQAAAAEAACcQAAAAELRRdc7nbLly8GZMqjhk90Lb83Cc1eYegL9b+8e7An2NuGn7/aBrbMZwSq9nkqtZjg==', NULL, 0, N'42e787aa-9588-4f0c-873b-3cf1ea3c6ce7', 0, N'inspectormanager_user', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [AccessFailedCount], [ConcurrencyStamp], [CreatedDate], [DisplayName], [Email], [EmailConfirmed], [FirstName], [LastModifiedDate], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [MiddleName], [ProfilePhoto], [City], [MobileNumber], [State], [StreetAddress1], [StreetAddress2], [ZipCode], [ProfilePhotoId]) VALUES (N'60e2ae0d-fe20-4fe1-2e8d-08d5f825e20c', 0, N'7bf046fd-1b8a-4626-8354-fd3949ebcd5d', CAST(N'2018-08-02T11:13:14.3662984' AS DateTime2), NULL, N'iginspector@mailinator.com', 1, NULL, CAST(N'2018-08-02T11:13:14.3662984' AS DateTime2), NULL, 1, NULL, N'IGINSPECTOR@MAILINATOR.COM', N'INSPECTOR_USER', N'AQAAAAEAACcQAAAAEC0QGcUq/hh/YcKDRr/DdXYWMlL4jg/Qdc2/NArI/mSVj/vIc5gzU1ISRJjps08RXw==', NULL, 0, N'3d1d2b73-0df3-4b4a-a4a3-74b1a90feade', 0, N'inspector_user', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
