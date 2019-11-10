SET IDENTITY_INSERT [dbo].[MedicalCentre] ON
INSERT INTO [dbo].[MedicalCentre] ([Id], [Name], [Phone]) VALUES (1, N'City Med Doctors ', N'02134567891')
INSERT INTO [dbo].[MedicalCentre] ([Id], [Name], [Phone]) VALUES (2, N'Healthy Life Medical', N'021456712341')
INSERT INTO [dbo].[MedicalCentre] ([Id], [Name], [Phone]) VALUES (3, N'Auckland Doctors', N'02234567890')
SET IDENTITY_INSERT [dbo].[MedicalCentre] OFF
SET IDENTITY_INSERT [dbo].[Doctor] ON
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (1, N'Sam Smith', CAST(200.00 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (2, N'David Francis', CAST(150.00 AS Decimal(18, 2)), 3)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (3, N'Hudson Davis', CAST(160.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
SET IDENTITY_INSERT [dbo].[Patient] ON
INSERT INTO [dbo].[Patient] ([Id], [Name], [IDNumber], [Phone]) VALUES (1, N'Samson Kent', N'LA604567', N'02134562234')
INSERT INTO [dbo].[Patient] ([Id], [Name], [IDNumber], [Phone]) VALUES (2, N'Garry Stephen', N'LA804567', N'0223456789')
SET IDENTITY_INSERT [dbo].[Patient] OFF
SET IDENTITY_INSERT [dbo].[Appointment] ON
INSERT INTO [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppointmentDate]) VALUES (1, 2, 2, N'2019-10-31 09:45:00')
INSERT INTO [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppointmentDate]) VALUES (2, 2, 1, N'2019-10-31 08:56:00')
SET IDENTITY_INSERT [dbo].[Appointment] OFF
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bbdea822-74b4-4a13-8ebe-9ad572ef5e71', N'admin@echannel.com', N'ADMIN@ECHANNEL.COM', N'admin@echannel.com', N'ADMIN@ECHANNEL.COM', 0, N'AQAAAAEAACcQAAAAEN51Mtusyw9uonSY4emJgGd/zlEV5VA6sDpapULCdPdrQ5Y5+WYE17tHCVzkGET8Ww==', N'4JG2Y3KEXQ4X6XNHIBC3UXMNG6Z25FEQ', N'9be3d127-53ca-4329-9f36-caa50641e428', NULL, 0, 0, NULL, 1, 0)
