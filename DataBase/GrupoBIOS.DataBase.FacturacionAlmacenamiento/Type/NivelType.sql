CREATE TYPE NivelType AS TABLE (
    IDNivel INT,
    NivelCentroOperativo INT,
    NivelNombre VARCHAR(510),
    NivelDiasGracia INT,
    NivelDiasCobertura INT,
    NivelPosicion FLOAT,
    NivelPrimerCobro INT,
    NivelSegundoCobro INT
);
