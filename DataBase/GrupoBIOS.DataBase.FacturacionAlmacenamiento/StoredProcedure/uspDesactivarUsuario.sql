-- =============================================
-- Author:		Sixto José Romero Martínez
-- Create date (dd-MM-yyyy): 11-04-2025
-- Description:	Se encarga de activar y desactivar el usuario
-- =============================================
CREATE PROCEDURE [dbo].[uspDesactivarUsuario]
	@IDUsuario	int
	,@Estado	int	
AS
BEGIN    			
    BEGIN TRY
			
		UPDATE Usuario SET Estado = @Estado 
		WHERE IDUsuario = @IDUsuario
		
		SELECT 'OK';

    END TRY
    BEGIN CATCH		
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		SELECT @ErrorMessage;
    END CATCH;
END