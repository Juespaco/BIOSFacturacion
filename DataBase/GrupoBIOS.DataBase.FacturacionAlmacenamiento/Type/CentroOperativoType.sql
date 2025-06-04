CREATE TYPE CentroOperativoType AS TABLE
(
    IDCentroOperativo INT,
    IDCompania INT,
    IDSiesaCO NVARCHAR(20),
    NombreCO NVARCHAR(500),
    ReferenciadeCobro NVARCHAR(500),
    PrefijodeFacturacion NVARCHAR(100),
    MotivodeFacturacion NVARCHAR(1000),
    BodegaEspeciales NVARCHAR(500),
    CorreoEnvioReporte NVARCHAR(500),
    FechaInicialCorte DATETIME,
    Estado BIT,
    CreadoPor NVARCHAR(300)
);
