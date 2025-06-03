CREATE TABLE [dbo].[Usuario](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IDRol] [int] NOT NULL,
	[IDCompania] [int] NOT NULL,
	[IDCentroOperativo] [int] NOT NULL,
	[FechaExpiracionRol] [date] NOT NULL,
	[NombredeUsuario] [nvarchar](250) NOT NULL,
	[Contrasena] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_CentroOperativo] FOREIGN KEY([IDCentroOperativo])
REFERENCES [dbo].[CentroOperativo] ([IDCentroOperativo])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_CentroOperativo]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Compania] FOREIGN KEY([IDCompania])
REFERENCES [dbo].[Compania] ([IDCompania])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Compania]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Role] FOREIGN KEY([IDRol])
REFERENCES [dbo].[Role] ([IDRol])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Role]
GO


