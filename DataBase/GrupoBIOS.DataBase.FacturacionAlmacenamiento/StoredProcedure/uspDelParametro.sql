-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 12-04-2025
-- Description:	Se encarga de cambiar el estado del Parametro.
-- exec uspDelParametro 1
-- =============================================
CREATE PROCEDURE [dbo].[uspDelParametro] 
	@IDParametro int
AS
BEGIN    	
    BEGIN TRY
		UPDATE Parametro
		SET Estado= 
		CASE	
			WHEN Estado = 1 THEN 0
			ELSE 1
		END
		WHERE IDParametro=@IDParametro

		SELECT 'OK';

    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);

		SELECT @ErrorMessage;
    END CATCH;
END