-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 12-04-2025
-- Description:	Se encarga de ingresar datos en la tabla Parametro.
-- exec uspCrearParametro 2,'Femenino','Genero Femenino',1,'System'
-- =============================================
CREATE PROCEDURE [dbo].[uspCrearParametro] 
	@IDClase int
	,@Nombre nvarchar (250)
	,@Descripcion nvarchar(250)
	,@Estado	bit = null
	,@CreadoPor nvarchar(150) = null
AS
BEGIN    	
	
    BEGIN TRY
		
		INSERT INTO Parametro
		(
			IDClase
			,Nombre
			,Descripcion
			,Estado
			,FechadeCreacion
			,CreadoPor
		)
		VALUES
		(
			@IDClase
			,@Nombre
			,@Descripcion
			,@Estado
			,GETDATE()
			,@CreadoPor
		)

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