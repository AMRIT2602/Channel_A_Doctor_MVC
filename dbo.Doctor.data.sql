SET IDENTITY_INSERT [dbo].[Doctor] ON
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (1, N'Sam Smith', CAST(200.00 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (2, N'David Francis', CAST(150.00 AS Decimal(18, 2)), 3)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (3, N'Hudson Davis', CAST(160.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
