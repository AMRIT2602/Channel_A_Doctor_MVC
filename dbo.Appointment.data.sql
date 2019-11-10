SET IDENTITY_INSERT [dbo].[Appointment] ON
INSERT INTO [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppointmentDate]) VALUES (1, 2, 2, N'2019-10-31 09:45:00')
INSERT INTO [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppointmentDate]) VALUES (2, 2, 1, N'2019-10-31 08:56:00')
SET IDENTITY_INSERT [dbo].[Appointment] OFF
