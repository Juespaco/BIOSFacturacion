-- =============================================
-- Author:		Sixto José Romero Martínez
-- Create date (dd-MM-yyyy): 07-04-2025
-- Description:	Se encarga de devolver el usuario junto a la información del usuario por ID.
-- exec uspGetUsuarioporId 7
-- =============================================
CREATE PROCEDURE uspGetUsuarioporId
    @IDUsuario int    
AS
BEGIN
    -- Primer conjunto: Datos del usuario
    SELECT 
        u.IDUsuario,
        u.IDRol,
		r.Rol as NombreRol,
        u.IDCompania,
        u.IDCentroOperativo,
        u.FechaExpiracionRol,
        u.NombredeUsuario,
        --u.Contrasena,
        u.Estado,
        u.FechadeCreacion,
        u.CreadoPor
    FROM Usuario u 
	INNER JOIN [Role] r ON u.IDRol = r.IDRol
    WHERE u.IDUsuario = @IDUsuario;    
    
    -- Segundo conjunto: InfoPersonal
    SELECT 
        ipe.IDInfoPersonal,
        ipe.IDUsuario,
        ipe.IDParametroTipoDocumento,
        ipe.Documento,
        ipe.Nombres,
        ipe.Apellidos,
        ipe.Direccion,
        ipe.Telefono,
        ipe.Correo,
        ipe.IDParametroGenero,
        ipe.FechadeCreacion,
        ipe.CreadoPor
    FROM InfoPersonal ipe
    INNER JOIN Usuario u ON ipe.IDUsuario = u.IDUsuario
    WHERE u.IDUsuario = @IDUsuario
END

