-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 12-04-2025
-- Description:	Se encarga de actualizar la tabla parametros.
-- exec uspActualizarParametro 1,1,'Masculino','Genero Masculino'
-- =============================================
CREATE PROCEDURE [dbo].[uspActualizarParametro] 
	@IDParametro int
	,@IDClase int
	,@Nombre nvarchar (250)
	,@Descripcion nvarchar(250)
	,@Estado	bit = null
	,@FechadeCreacion datetime = null
	,@CreadoPor nvarchar(150) = null
AS
BEGIN    	
	
    BEGIN TRY
		UPDATE Parametro
		SET IDClase=@IDClase,
		Nombre=@Nombre,
		Descripcion=@Descripcion
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