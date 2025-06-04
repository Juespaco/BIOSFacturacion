CREATE PROCEDURE sp_CentroOperativo_CrearActualizar
    @CentroOperativos CentroOperativoType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    MERGE INTO CentroOperativo AS Target
    USING @CentroOperativos AS Source
    ON Target.IDCentroOperativo = Source.IDCentroOperativo

    WHEN MATCHED THEN 
        UPDATE SET
            Target.IDCompania = Source.IDCompania,
            Target.IDSiesaCO = Source.IDSiesaCO,
            Target.NombreCO = Source.NombreCO,
            Target.ReferenciadeCobro = Source.ReferenciadeCobro,
            Target.PrefijodeFacturacion = Source.PrefijodeFacturacion,
            Target.MotivodeFacturacion = Source.MotivodeFacturacion,
            Target.BodegaEspeciales = Source.BodegaEspeciales,
            Target.CorreoEnvioReporte = Source.CorreoEnvioReporte,
            Target.FechaInicialCorte = Source.FechaInicialCorte,
            Target.CobroPNC = Source.CobroPNC,
            Target.Estado = Source.Estado,
            Target.CreadoPor = Source.CreadoPor

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            IDCompania, IDSiesaCO, NombreCO, ReferenciadeCobro, 
            PrefijodeFacturacion, MotivodeFacturacion, BodegaEspeciales, 
            CorreoEnvioReporte, FechaInicialCorte, CobroPNC, Estado,
            CreadoPor
        )
        VALUES (
            Source.IDCompania, Source.IDSiesaCO, Source.NombreCO, Source.ReferenciadeCobro,
            Source.PrefijodeFacturacion, Source.MotivodeFacturacion, Source.BodegaEspeciales,
            Source.CorreoEnvioReporte, Source.FechaInicialCorte, Source.CobroPNC, Source.Estado,
            Source.CreadoPor
        );
END
