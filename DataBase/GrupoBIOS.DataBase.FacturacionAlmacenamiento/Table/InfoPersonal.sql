CREATE TABLE [dbo].[InfoPersonal](
	[IDInfoPersonal] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDParametroTipoDocumento] [int] NOT NULL,
	[Documento] [nvarchar](50) NOT NULL,
	[Nombres] [nvarchar](250) NOT NULL,
	[Apellidos] [nvarchar](150) NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](250) NOT NULL,
	[IDParametroGenero] [int] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_InfoPersonal] PRIMARY KEY CLUSTERED 
(
	[IDInfoPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[InfoPersonal]  WITH CHECK ADD  CONSTRAINT [FK_InfoPersonal_Parametro] FOREIGN KEY([IDParametroTipoDocumento])
REFERENCES [dbo].[Parametro] ([IDParametro])
GO

ALTER TABLE [dbo].[InfoPersonal] CHECK CONSTRAINT [FK_InfoPersonal_Parametro]
GO

ALTER TABLE [dbo].[InfoPersonal]  WITH CHECK ADD  CONSTRAINT [FK_InfoPersonal_Parametro1] FOREIGN KEY([IDParametroGenero])
REFERENCES [dbo].[Parametro] ([IDParametro])
GO

ALTER TABLE [dbo].[InfoPersonal] CHECK CONSTRAINT [FK_InfoPersonal_Parametro1]
GO

ALTER TABLE [dbo].[InfoPersonal]  WITH CHECK ADD  CONSTRAINT [FK_InfoPersonal_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([IDUsuario])
GO

ALTER TABLE [dbo].[InfoPersonal] CHECK CONSTRAINT [FK_InfoPersonal_Usuario]
GO


