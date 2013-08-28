
ALTER LOGIN tsci WITH PASSWORD = 'tsci@@~~';
CREATE LOGIN tsci WITH password = 'tsci@@~~';
CREATE USER tsci for Login tsci;
GO

--Convertirlo Admin
EXEC master..sp_addsrvrolemember @loginame = N'tsci', @rolename = N'sysadmin';
GO 