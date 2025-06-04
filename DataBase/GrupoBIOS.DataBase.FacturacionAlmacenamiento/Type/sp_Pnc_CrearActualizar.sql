CREATE PROCEDURE sp_Pnc_CrearActualizar
    @Pncs PncType READONLY
AS
BEGIN
    MERGE INTO Pnc AS target
    USING @Pncs AS source
    ON target.IDPnc = source.IDPnc

    WHEN MATCHED THEN
        UPDATE SET 
            target.CoPnc = source.CoPnc,
            target.NombrePnc = source.NombrePnc,
            target.CodigoPnc = source.CodigoPnc,
            target.TarifaPnc = source.TarifaPnc,
            target.FleteidaPnc = source.FleteidaPnc,
            target.FleteregPnc = source.FleteregPnc

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (CoPnc, NombrePnc, CodigoPnc, TarifaPnc, FleteidaPnc, FleteregPnc)
        VALUES (source.CoPnc, source.NombrePnc, source.CodigoPnc, source.TarifaPnc, source.FleteidaPnc, source.FleteregPnc);
END
