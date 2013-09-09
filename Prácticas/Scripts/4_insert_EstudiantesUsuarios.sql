USE [TSCI]
GO
DELETE FROM [dbo].[Estudiantes];
DELETE FROM [dbo].[Usuarios];
DELETE FROM [dbo].[ConfigModulos];

SET IDENTITY_INSERT [dbo].[Usuarios] ON 
INSERT INTO [dbo].[Usuarios]  ([Id], [NombreUsuario], [Password]) VALUES (1, 'admin' ,'123456');
INSERT INTO [dbo].[Usuarios]  ([Id], [NombreUsuario], [Password]) VALUES (2, 'hugo' ,'123456');
SET IDENTITY_INSERT [dbo].[Usuarios] OFF

SET IDENTITY_INSERT [dbo].[Estudiantes] ON 
INSERT INTO [dbo].[Estudiantes] ([Id], [Nombre], [ApP], [ApM], [Matricula], [Edad], [IdUsuario]) VALUES (1, 'Luis', 'Montané', 'Jiménez', 'S03005434', 27, 1);
INSERT INTO [dbo].[Estudiantes] ([Id], [Nombre], [ApP], [ApM], [Matricula], [Edad], [IdUsuario]) VALUES (2, 'Gerardo', 'Montero', 'López', 'S03005414', 37, 1);
SET IDENTITY_INSERT [dbo].[Estudiantes] OFF 


SET IDENTITY_INSERT [dbo].[ConfigModulos] ON 
INSERT INTO [dbo].[ConfigModulos] ([Id], [Modulo], [Forma], [Campo], [RE]) VALUES (1, 'RH', 'FrmEstudiantes', 'txtNombre', '^[a-z]+$');
INSERT INTO [dbo].[ConfigModulos] ([Id], [Modulo], [Forma], [Campo], [RE]) VALUES (2, 'RH', 'FrmEstudiantes', 'txtApP', '^[a-z ,.''-]+$');
INSERT INTO [dbo].[ConfigModulos] ([Id], [Modulo], [Forma], [Campo], [RE]) VALUES (3, 'RH', 'FrmEstudiantes', 'txtApM', '^[a-z ,.''-]+$');
INSERT INTO [dbo].[ConfigModulos] ([Id], [Modulo], [Forma], [Campo], [RE]) VALUES (4, 'RH', 'FrmEstudiantes', 'txtMatricula', '^S(\d{8})$');
INSERT INTO [dbo].[ConfigModulos] ([Id], [Modulo], [Forma], [Campo], [RE]) VALUES (5, 'RH', 'FrmEstudiantes', 'txtEdad', '^\d{1,3}$');
INSERT INTO [dbo].[ConfigModulos] ([Id], [Modulo], [Forma], [Campo], [RE]) VALUES (6, 'RH', 'FrmEstudiantes', 'Email', '^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$');
SET IDENTITY_INSERT [dbo].[ConfigModulos] OFF 

GO


