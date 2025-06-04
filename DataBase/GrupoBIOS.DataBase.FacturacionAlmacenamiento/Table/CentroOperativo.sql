CREATE TABLE [dbo].[CentroOperativo](
	[IDCentroOperativo] [int] IDENTITY(1,1) NOT NULL,
	[IDCompania] [int] NOT NULL,
	[IDSiesaCO] [int] NOT NULL,
	[NombreCO] [nvarchar](250) NOT NULL,
	[ReferenciadeCobro] [nvarchar](250) NOT NULL,
	[PrefijodeFacturacion] [nvarchar](50) NOT NULL,
	[MotivodeFacturacion] [nvarchar](500) NOT NULL,
	[BodegaEspeciales] [nvarchar](250) NOT NULL,
	[CorreoEnvioReporte] [nvarchar](250) NOT NULL,
	[FechaInicialCorte] [datetime] NOT NULL,
	[CobroPNC] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL DEFAULT GETDATE(),
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_CentroOperativo] PRIMARY KEY CLUSTERED 
(
	[IDCentroOperativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO