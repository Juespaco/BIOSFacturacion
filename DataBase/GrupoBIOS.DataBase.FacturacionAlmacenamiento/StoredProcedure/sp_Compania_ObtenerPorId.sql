CREATE PROCEDURE [dbo].[sp_Compania_ObtenerPorId]
    @IDSiesa INT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Consultar la compañía específica
        SELECT 
            [IDCompania],
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
        FROM 
            [dbo].[Compania]
        WHERE 
            [IDSiesa] = @IDSiesa;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		select @ErrorMessage
    END CATCH;
END;
