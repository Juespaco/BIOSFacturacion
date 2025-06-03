CREATE PROCEDURE sp_Compania_Actualizar
    @IDCompania INT,
    @NombreCompania NVARCHAR(255) = NULL,
    @IDSiesa INT = NULL,
    @NombreBD NVARCHAR(255) = NULL,
    @NombreConexionBD NVARCHAR(255) = NULL,
    @UrlWebServiceSiesa NVARCHAR(500) = NULL,
    @UsuarioWebService NVARCHAR(100) = NULL,
    @ClaveWebService NVARCHAR(100) = NULL,
    @Estado BIT = NULL    
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
       
        -- Actualizar solo los campos proporcionados (UPDATE dinámico)
        UPDATE [dbo].[Compania]
        SET
            [NombreCompania] = ISNULL(@NombreCompania, [NombreCompania]),
            [IDSiesa] = ISNULL(@IDSiesa, [IDSiesa]),
            [NombreBD] = ISNULL(@NombreBD, [NombreBD]),
            [NombreConexionBD] = ISNULL(@NombreConexionBD, [NombreConexionBD]),
            [UrlWebServiceSiesa] = ISNULL(@UrlWebServiceSiesa, [UrlWebServiceSiesa]),
            [UsuarioWebService] = ISNULL(@UsuarioWebService, [UsuarioWebService]),
            [ClaveWebService] = ISNULL(@ClaveWebService, [ClaveWebService]),
            [Estado] = ISNULL(@Estado, [Estado])            
        WHERE
            [IDCompania] = @IDCompania;
                        
        COMMIT TRANSACTION;

		-- Retornar el número de filas afectadas
        SELECT 'OK'

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;            
        -- Retornar información del error
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        SELECT @ErrorMessage
    END CATCH;
END;
