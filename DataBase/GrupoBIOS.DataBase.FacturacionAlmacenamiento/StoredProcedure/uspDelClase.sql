-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 12-04-2025
-- Description:	Se encarga de cambiar el estado de Clase.
-- exec uspDelClase 1
-- =============================================
CREATE PROCEDURE [dbo].[uspDelClase] 
	@IDClase int
AS
BEGIN    	
    BEGIN TRY
		UPDATE Clase
		SET Estado= 
		CASE	
			WHEN Estado = 1 THEN 0
			ELSE 1
		END
		WHERE IDClase=@IDClase

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