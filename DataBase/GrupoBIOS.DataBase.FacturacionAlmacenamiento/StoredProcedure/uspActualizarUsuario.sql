-- =============================================
-- Author:		Sixto José Romero Martínez
-- Create date (dd-MM-yyyy): 07-04-2025
-- Description:	actualiza el usuario en la tabla Usuario
-- =============================================
CREATE PROCEDURE [dbo].[uspActualizarUsuario]
	@IDUsuario	int
	,@IDRol	int
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
		IF @Contrasena IS NULL
		BEGIN
			UPDATE Usuario SET 
				IDRol = @IDRol
				,IDCompania = @IDCompania
				,IDCentroOperativo = @IDCentroOperativo
				,FechaExpiracionRol = @FechaExpiracionRol
				,NombredeUsuario = @NombredeUsuario				
				,Estado = @Estado
			WHERE IDUsuario = @IDUsuario		
		END
		ELSE
		BEGIN
			UPDATE Usuario SET 
				IDRol = @IDRol
				,IDCompania = @IDCompania
				,IDCentroOperativo = @IDCentroOperativo
				,FechaExpiracionRol = @FechaExpiracionRol
				,NombredeUsuario = @NombredeUsuario
				,Contrasena = @Contrasena
				,Estado = @Estado
			WHERE IDUsuario = @IDUsuario		
		END
		
		UPDATE InfoPersonal
        SET 
            IDParametroTipoDocumento = JSON_VALUE(@JsonInfoPersona, '$.IDParametroTipoDocumento'),
            Documento = JSON_VALUE(@JsonInfoPersona, '$.Documento'),
            Nombres = JSON_VALUE(@JsonInfoPersona, '$.Nombres'),
            Apellidos = JSON_VALUE(@JsonInfoPersona, '$.Apellidos'),
            Direccion = JSON_VALUE(@JsonInfoPersona, '$.Direccion'),
            Telefono = JSON_VALUE(@JsonInfoPersona, '$.Telefono'),
            Correo = JSON_VALUE(@JsonInfoPersona, '$.Correo'),
            IDParametroGenero = JSON_VALUE(@JsonInfoPersona, '$.IDParametroGenero')            
        WHERE IDUsuario = @IDUsuario;

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

