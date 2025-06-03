CREATE PROCEDURE sp_Compania_CambiarEstado
    @IDCompania INT,
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
                
        -- Actualizar el estado y datos de auditoría
        UPDATE [dbo].[Compania]
        SET
            [Estado] = @Estado            
        WHERE
            [IDCompania] = @IDCompania;
        
        SELECT 'OK'
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        
        ROLLBACK TRANSACTION;
            
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        SELECT @ErrorMessage;
    END CATCH;
END;
GO