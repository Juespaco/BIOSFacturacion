-- =============================================
-- Author:		Sixto José Romero Martínez
-- Create date (dd-MM-yyyy): 29-03-2025
-- Description:	Se encarga de listar todos los usuarios
-- =============================================
CREATE PROCEDURE [dbo].[uspGetUsuarioAll]
AS
	SELECT IDUsuario
	,u.IDRol
	,r.Rol as NombreRol
	,u.IDCompania
	,u.IDCentroOperativo
	,u.FechaExpiracionRol
	,u.NombredeUsuario
	,'' as Contrasena
	,u.Estado
	,u.FechadeCreacion
	,u.CreadoPor FROM Usuario u
	INNER JOIN [Role] r ON u.IDRol = r.IDRol