USE [TSCI]
GO
DELETE FROM [dbo].[Estudiantes];
DELETE FROM [dbo].[Usuarios];

SET IDENTITY_INSERT [dbo].[Usuarios] ON 
INSERT INTO [dbo].[Usuarios]  ([Id], [NombreUsuario], [Password]) VALUES (1, 'admin' ,'123456');
INSERT INTO [dbo].[Usuarios]  ([Id], [NombreUsuario], [Password]) VALUES (2, 'hugo' ,'123456');
SET IDENTITY_INSERT [dbo].[Usuarios] OFF

SET IDENTITY_INSERT [dbo].[Estudiantes] ON 
INSERT INTO [dbo].[Estudiantes] ([Id], [Nombre], [ApP], [ApM], [Matricula], [Edad], [IdUsuario]) VALUES (1, 'Luis', 'Montané', 'Jiménez', 'S03005434', 27, 1);
INSERT INTO [dbo].[Estudiantes] ([Id], [Nombre], [ApP], [ApM], [Matricula], [Edad], [IdUsuario]) VALUES (2, 'Gerardo', 'Montero', 'López', 'S03005414', 37, 1);

SET IDENTITY_INSERT [dbo].[Estudiantes] OFF 

GO


