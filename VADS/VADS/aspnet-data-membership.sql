SET IDENTITY_INSERT [dbo].[OwnerModels] ON 

INSERT [dbo].[OwnerModels] ([Id], [Name], [LastName], [Email], [Phone]) VALUES (2, N'Maximo', N'Dominguez', N'mamodom@gmail.com', N'8099631419')
INSERT [dbo].[OwnerModels] ([Id], [Name], [LastName], [Email], [Phone]) VALUES (3, N'Jose Miguel', N'Lopez', N'jmlc11@outlook.com', N'8492017122')
SET IDENTITY_INSERT [dbo].[OwnerModels] OFF
SET IDENTITY_INSERT [dbo].[VehicleInfoModels] ON 

INSERT [dbo].[VehicleInfoModels] ([VehicleId], [OwnerId], [Plate], [Year], [VehicleBrand], [VehicleModel]) VALUES (9, 3, N'A123123', N'2004', N'Honda', N'Civic')
SET IDENTITY_INSERT [dbo].[VehicleInfoModels] OFF
SET IDENTITY_INSERT [dbo].[VehicleStatusModels] ON 

INSERT [dbo].[VehicleStatusModels] ([StatusId], [PidDistance], [PidRuntime], [PidCoolantTemp], [VehicleId], [PidSpeed], [PidRpm], [PidThrottle], [PidEngineLoad], [PidAbsEngineLoad], [PidIntakeTemp], [PidIntakePressure], [PidMafFlow], [PidFuelPressure], [PidFuelLevel], [PidBarometric], [PidTimingAdvance]) VALUES (8, NULL, NULL, NULL, 9, 100, 2000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VehicleStatusModels] OFF
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3, N'haroldadmin')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'canEdit')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3, 1)
SET IDENTITY_INSERT [dbo].[TotoModels] ON 

INSERT [dbo].[TotoModels] ([TotoId], [TotoName]) VALUES (1, N'sdf')
INSERT [dbo].[TotoModels] ([TotoId], [TotoName]) VALUES (2, N'popolo')
SET IDENTITY_INSERT [dbo].[TotoModels] OFF
SET IDENTITY_INSERT [dbo].[VehicleBrands] ON 

INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (17, N'Toyota', 1)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (18, N'Honda', 2)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (19, N'Mitsubishi', 3)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (20, N'Peugeot', 4)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (21, N'Renault', 5)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (22, N'Nissan', 6)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (23, N'Subaru', 7)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (24, N'Mazda', 8)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (25, N'Suzuki', 9)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (26, N'Chevrolet', 10)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (27, N'Volvo', 11)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (28, N'Dodge', 12)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (29, N'Infinity', 13)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (30, N'Seat', 14)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (31, N'Chrystler', 15)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (32, N'Opel', 16)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (33, N'Jaguar', 17)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (34, N'Citroen', 18)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (35, N'Buik', 19)
INSERT [dbo].[VehicleBrands] ([VehicleBrandId], [Brand], [BrandId]) VALUES (36, N'Fiat', 20)
SET IDENTITY_INSERT [dbo].[VehicleBrands] OFF
SET IDENTITY_INSERT [dbo].[VehicleModels] ON 

INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (3, N'Corolla', 1)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (4, N'Camry', 1)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (5, N'Yaris', 1)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (6, N'Civic', 2)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (7, N'Accord', 2)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (8, N'Fit', 2)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (9, N'Lancer', 3)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (10, N'Galant', 3)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (11, N'Mirage', 3)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (12, N'407', 4)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (13, N'307', 4)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (14, N'206', 4)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (15, N'Cleo', 5)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (16, N'Megane', 5)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (17, N'Stepway', 5)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (18, N'Sentra', 6)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (19, N'Tidda', 6)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (20, N'Versa', 6)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (21, N'Impreza', 7)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (22, N'Forester', 7)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (23, N'Outback', 7)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (24, N'2', 8)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (25, N'3', 8)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (26, N'5', 8)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (27, N'Aerio', 9)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (28, N'Samurai', 9)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (29, N'Grand Vitara', 9)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (30, N'Suburban', 10)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (31, N'Tahoe', 10)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (32, N'Camaro', 10)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (33, N'S80', 11)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (34, N'V70', 11)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (35, N'V60', 11)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (36, N'Durango', 12)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (37, N'Journey', 12)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (38, N'Viper', 12)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (39, N'Q50', 13)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (40, N'Q60', 13)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (41, N'QX50', 13)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (42, N'Toledo', 14)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (43, N'Leon', 14)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (44, N'Altea', 14)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (45, N'300', 15)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (46, N'Delta', 15)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (47, N'Grand Voyager', 15)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (48, N'Adam', 16)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (49, N'Corsa', 16)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (50, N'Astra', 16)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (51, N'XJ', 17)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (52, N'XK', 17)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (53, N'XF', 17)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (54, N'C3', 18)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (55, N'C4', 18)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (56, N'Metropolis', 18)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (57, N'Enclave', 19)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (58, N'Riviera', 19)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (59, N'LaCrosse', 19)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (60, N'Punto', 20)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (61, N'Stilo', 20)
INSERT [dbo].[VehicleModels] ([VehicleModelId], [Model], [BrandId]) VALUES (62, N'Panda', 20)
SET IDENTITY_INSERT [dbo].[VehicleModels] OFF
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(0x0000A1FF013EFB89 AS DateTime), NULL, 1, NULL, 0, N'ANQV/9T63TL3pLswFJV7u163zrUDFHsKqQ3Iws0ONiXLYssOwzafWiWCx9kPixZ6QQ==', CAST(0x0000A1FF013EFB89 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (2, CAST(0x0000A1FF014875B0 AS DateTime), NULL, 1, NULL, 0, N'AEtYQJDZ/wyE8xqllEgpT96akRaIkhtPXmSNFFmGSMGCT4S0ET+o9klowSoiFLXQvQ==', CAST(0x0000A1FF014875B0 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3, CAST(0x0000A20200F60C32 AS DateTime), NULL, 1, CAST(0x0000A20600489C05 AS DateTime), 0, N'ADiytzEO76K2Nw1Tra5TZ7JP0/4C6Sx6kITJXTYHlH5d3nntLhJfvPRDz/bfaKAIjQ==', CAST(0x0000A20200F60C32 AS DateTime), N'', NULL, NULL)
