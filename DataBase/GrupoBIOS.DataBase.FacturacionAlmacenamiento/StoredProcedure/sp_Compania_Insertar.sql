CREATE PROCEDURE sp_Compania_Insertar
    @NombreCompania NVARCHAR(255),
    @IDSiesa INT = NULL,
    @NombreBD NVARCHAR(255) = NULL,
    @NombreConexionBD NVARCHAR(255) = NULL,
    @UrlWebServiceSiesa NVARCHAR(500) = NULL,
    @UsuarioWebService NVARCHAR(100) = NULL,
    @ClaveWebService NVARCHAR(100) = NULL,    
    @CreadoPor NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY                
        BEGIN TRANSACTION;
        INSERT INTO [dbo].[Compania] (
            [NombreCompania],
            [IDSiesa],
            [NombreBD],
            [NombreConexionBD],
            [UrlWebServiceSiesa],
            [UsuarioWebService],
            [ClaveWebService],
            [Estado],
            [FechadeCreacion],
            [CreadoPor]
        )
        VALUES (
            @NombreCompania,
            @IDSiesa,
            @NombreBD,
            @NombreConexionBD,
            @UrlWebServiceSiesa,
            @UsuarioWebService,
            @ClaveWebService,
            1,
            GETDATE(), -- Fecha actual automática
            @CreadoPor
        );

        COMMIT TRANSACTION;

		SELECT 'OK';

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;            
        -- Retornar información del error
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();        
        SELECT @ErrorMessage            
    END CATCH;
END;
