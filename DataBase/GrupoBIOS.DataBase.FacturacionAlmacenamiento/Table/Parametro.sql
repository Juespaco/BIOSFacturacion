CREATE TABLE [dbo].[Parametro](
	[IDParametro] [int] IDENTITY(1,1) NOT NULL,
	[IDClase] [int] NOT NULL,
	[Nombre] [nvarchar](250) NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Parametro] PRIMARY KEY CLUSTERED 
(
	[IDParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Parametro]  WITH CHECK ADD  CONSTRAINT [FK_Parametro_Clase] FOREIGN KEY([IDClase])
REFERENCES [dbo].[Clase] ([IDClase])
GO

ALTER TABLE [dbo].[Parametro] CHECK CONSTRAINT [FK_Parametro_Clase]
GO


