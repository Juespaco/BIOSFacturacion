CREATE TYPE CentroOperativoType AS TABLE
(
    IDCentroOperativo INT,
    IDCompania INT,
    IDSiesaCO INT,
    NombreCO NVARCHAR(250),
    ReferenciadeCobro NVARCHAR(250),
    PrefijodeFacturacion NVARCHAR(50),
    MotivodeFacturacion NVARCHAR(500),
    BodegaEspeciales NVARCHAR(250),
    CorreoEnvioReporte NVARCHAR(250),
    FechaInicialCorte DATETIME,
    CobroPNC INT,
    Estado BIT,
    FechadeCreacion DATETIME,
    CreadoPor NVARCHAR(150)
);
