CREATE PROCEDURE sp_Compania_ObtenerTodos
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Consultar todas las compañías (con filtro opcional por estado)
        SELECT 
            IDCompania,
            NombreCompania,
            IDSiesa,
            NombreBD,
            NombreConexionBD,
            UrlWebServiceSiesa,
            UsuarioWebService,
            ClaveWebService,
            Estado,
            FechadeCreacion,
            CreadoPor
        FROM 
            dbo.Compania
        ORDER BY 
            NombreCompania ASC;  -- Ordenar alfabéticamente
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        SELECT @ErrorMessage
    END CATCH;
END;
GO