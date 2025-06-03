-- =============================================
-- Author:		Oscar Donato Garcia
-- Create date (dd-MM-yyyy): 12-04-2025
-- Description:	Se encarga de actualizar la tabla CLase.
-- exec uspActualizarClase 2,'Genero','Genero'
-- =============================================
CREATE PROCEDURE [dbo].[uspActualizarClase] 
	@IDClase int
	,@Nombre nvarchar (250)
	,@Descripcion nvarchar(250)
	,@Estado	bit = null
	,@FechadeCreacion datetime = null
	,@CreadoPor nvarchar(150) = null
AS
BEGIN    	
	
    BEGIN TRY
		UPDATE Clase
		SET Nombre=@Nombre,
		Descripcion=@Descripcion
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