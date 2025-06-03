-- =============================================
-- Author:		Sixto José Romero Martínez
-- Create date (dd-MM-yyyy): 29-03-2025
-- Description:	Crea el usuario en la tabla Usuario
-- =============================================
CREATE PROCEDURE [dbo].[uspCrearUsuario]
	@IDRol	int
	,@IDCompania	int
	,@IDCentroOperativo	int
	,@FechaExpiracionRol	date
	,@NombredeUsuario	nvarchar(250)
	,@Contrasena	nvarchar(MAX)
	,@Estado	bit
	,@CreadoPor nvarchar(150)
	,@JsonInfoPersona nvarchar(MAX)
AS
BEGIN    	
	BEGIN TRANSACTION; -- Iniciar transacción
	
    BEGIN TRY

		DECLARE @IDUsuario INT = 1;
		
		INSERT INTO Usuario 
		(
			IDRol
			,IDCompania
			,IDCentroOperativo
			,FechaExpiracionRol
			,NombredeUsuario
			,Contrasena
			,Estado
			,FechadeCreacion
			,CreadoPor
		)
		VALUES
		(
			@IDRol
			,@IDCompania
			,@IDCentroOperativo
			,@FechaExpiracionRol
			,@NombredeUsuario
			,@Contrasena
			,@Estado
			,GETDATE()
			,@CreadoPor
		)

		SET @IDUsuario = SCOPE_IDENTITY();		

		/*Se registra la información personal del Usuario*/
		INSERT INTO InfoPersonal 
		(
			IDUsuario
			,IDParametroTipoDocumento
			,Documento
			,Nombres
			,Apellidos
			,Direccion
			,Telefono
			,Correo
			,IDParametroGenero
			,FechadeCreacion
			,CreadoPor
		)
		SELECT TOP 1
			@IDUsuario,                        
			JSON_VALUE(@JsonInfoPersona, '$.IDParametroTipoDocumento'),
            JSON_VALUE(@JsonInfoPersona, '$.Documento'),
            JSON_VALUE(@JsonInfoPersona, '$.Nombres'),
			JSON_VALUE(@JsonInfoPersona, '$.Apellidos'),
			JSON_VALUE(@JsonInfoPersona, '$.Direccion'),
			JSON_VALUE(@JsonInfoPersona, '$.Telefono'),
			JSON_VALUE(@JsonInfoPersona, '$.Correo'),
			JSON_VALUE(@JsonInfoPersona, '$.IDParametroGenero'),
			GETDATE(),
			@CreadoPor
        FROM OPENJSON(@JsonInfoPersona);

		COMMIT TRANSACTION;

		SELECT 'OK';

    END TRY
    BEGIN CATCH
		ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);

		SELECT @ErrorMessage;
    END CATCH;
END

GO


