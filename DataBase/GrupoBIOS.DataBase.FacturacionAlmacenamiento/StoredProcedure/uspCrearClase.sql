-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 12-04-2025
-- Description:	Se encarga de ingresar datos en la tabla CLase.
-- exec uspCrearClase 'Genero','Genero',1,'System'
-- =============================================
CREATE PROCEDURE [dbo].[uspCrearClase] 
	@Nombre nvarchar (250)
	,@Descripcion nvarchar(250)
	,@Estado	bit = null
	,@CreadoPor nvarchar(150) = null
AS
BEGIN    	
	
    BEGIN TRY
		
		INSERT INTO Clase
		(
			Nombre
			,Descripcion
			,Estado
			,FechadeCreacion
			,CreadoPor
		)
		VALUES
		(
			@Nombre
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