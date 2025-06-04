CREATE PROCEDURE sp_Nivel_CrearActualizar
    @Niveles NivelType READONLY
AS
BEGIN
    MERGE INTO Nivel AS target
    USING @Niveles AS source
    ON target.IDNivel = source.IDNivel

    WHEN MATCHED THEN
        UPDATE SET 
            target.NivelCentroOperativo = source.NivelCentroOperativo,
            target.NivelNombre = source.NivelNombre,
            target.NivelDiasGracia = source.NivelDiasGracia,
            target.NivelDiasCobertura = source.NivelDiasCobertura,
            target.NivelPosicion = source.NivelPosicion,
            target.NivelPrimerCobro = source.NivelPrimerCobro,
            target.NivelSegundoCobro = source.NivelSegundoCobro

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            NivelCentroOperativo, NivelNombre, NivelDiasGracia, NivelDiasCobertura,
            NivelPosicion, NivelPrimerCobro, NivelSegundoCobro
        )
        VALUES (
            source.NivelCentroOperativo, source.NivelNombre, source.NivelDiasGracia, source.NivelDiasCobertura,
            source.NivelPosicion, source.NivelPrimerCobro, source.NivelSegundoCobro
        );
END
