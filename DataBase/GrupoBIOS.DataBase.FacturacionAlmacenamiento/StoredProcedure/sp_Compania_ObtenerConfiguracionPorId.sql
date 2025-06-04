CREATE PROCEDURE [dbo].[sp_Compania_ObtenerConfiguracionPorId]
						
    @IDSiesa INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        
        SELECT 
            IDCompania,
            NombreCompania,
            IDSiesa,
            NombreBD,
            NombreConexionBD,
            UrlWebServiceSiesa,
            UsuarioWebService,
            ClaveWebService,
            Estado,
            FechadeCreacion,
            CreadoPor
        FROM dbo.Compania
        WHERE IDSiesa = @IDSiesa;

        SELECT 
            IdNotificacion,
            n.IdCompania,
            Puerto,
            SSL,
            Host,
            EmailRemitente,
            NombreRemitente,
            UsuarioEmail,
            ContrasenaEmail,
            n.Estado,
            FechaCreacion,
            n.CreadoPor
        FROM dbo.Notificaciones n
        INNER JOIN dbo.Compania com ON n.IdCompania = com.IDCompania
        WHERE com.IDSiesa = @IDSiesa;

        SELECT 
            IDNivel,
            NivelPosicion,
            NivelPrimerCobro,
            NivelSegundoCobro,
            NivelPNCCobro,
            NivelDiasCobertura,
            NivelDiasGracia,
            NivelNombre,
            NivelCentroOperativo
        FROM dbo.Nivel ni
		INNER JOIN dbo.CentroOperativo co ON co.IDCentroOperativo = ni.NivelCentroOperativo
		INNER JOIN dbo.Compania com ON com.IDCompania = co.IDCompania 
        WHERE com.IDSiesa = @IDSiesa;

        SELECT 
            IDCentroOperativo,
            co.IDCompania,
            IDSiesaCO,
            NombreCO,
            ReferenciadeCobro,
            PrefijodeFacturacion,
            MotivodeFacturacion,
            BodegaEspeciales,
            CorreoEnvioReporte,
            FechaInicialCorte,
            FechaPrimerCobro,
            FechaSegundoCobro,
            FechaCobroPNC,
            DefinicioPrimerCobro,
            DefinicioSegundoCobro,
            CobroPNC,
            co.Estado,
            co.FechadeCreacion,
            co.CreadoPor
        FROM dbo.CentroOperativo co
        INNER JOIN dbo.Compania com ON com.IDCompania = co.IDCompania 
        WHERE com.IDSiesa = @IDSiesa;

        SELECT 
            IDPnc,
            CoPnc,
            NombrePnc,
            CodigoPnc,
            TarifaPnc,
            FleteidaPnc,
            FleteregPnc
        FROM dbo.Pnc pn
		INNER JOIN dbo.CentroOperativo co ON pn.CoPnc = co.IDCentroOperativo
		INNER JOIN dbo.Compania com ON com.IDCompania = co.IDCompania 
        WHERE com.IDSiesa = @IDSiesa;
       		
        SELECT 
            IdExcepcion,
            ex.IdCompania,
            Planta,
            Nit,
            NombreCliente,
            ex.Estado,
            FechaCreacion,
            ex.CreadoPor
        FROM dbo.Excepciones ex
        INNER JOIN dbo.Compania com ON com.IDCompania = ex.IdCompania 
        WHERE com.IDSiesa = @IDSiesa;

    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        SELECT @ErrorMessage AS Error;
    END CATCH
END;
