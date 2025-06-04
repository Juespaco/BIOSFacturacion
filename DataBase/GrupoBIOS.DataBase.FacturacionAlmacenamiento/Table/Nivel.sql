
CREATE TABLE Nivel (
    IDNivel INT IDENTITY(1,1) PRIMARY KEY,
    NivelCentroOperativo INT NOT NULL,
    NivelNombre VARCHAR(510) NOT NULL,
    NivelDiasGracia INT NOT NULL,
    NivelDiasCobertura INT NOT NULL,
    NivelPosicion FLOAT NOT NULL DEFAULT(0),
    NivelPrimerCobro INT NOT NULL,
    NivelSegundoCobro INT NOT NULL
);
