CREATE TABLE [dbo].[CentroOperativo] (
    [IDCentroOperativo] INT IDENTITY(1,1) NOT NULL,
    [IDCompania] INT NOT NULL,
    [IDSiesaCO] NVARCHAR(20) NOT NULL,
    [NombreCO] NVARCHAR(500) NOT NULL,
    [ReferenciadeCobro] NVARCHAR(500) NOT NULL,
    [PrefijodeFacturacion] NVARCHAR(100) NOT NULL,
    [MotivodeFacturacion] NVARCHAR(1000) NOT NULL,
    [BodegaEspeciales] NVARCHAR(500) NOT NULL,
    [CorreoEnvioReporte] NVARCHAR(MAX) NOT NULL,
    [FechaInicialCorte] DATETIME NOT NULL,
    [Estado] BIT NOT NULL,
    [FechadeCreacion] DATETIME NOT NULL DEFAULT GETDATE(),
    [CreadoPor] NVARCHAR(300) NOT NULL,

    CONSTRAINT [PK_CentroOperativo] PRIMARY KEY CLUSTERED ([IDCentroOperativo] ASC)
);
