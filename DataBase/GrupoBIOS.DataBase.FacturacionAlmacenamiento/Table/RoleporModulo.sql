CREATE TABLE [dbo].[RoleporModulo](
	[IDRolxModulo] [int] IDENTITY(1,1) NOT NULL,
	[IDRol] [int] NOT NULL,
	[IDModulo] [int] NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NULL,
	[CreadoPor] [nvarchar](150) NULL,
 CONSTRAINT [PK_RoleporModulo] PRIMARY KEY CLUSTERED 
(
	[IDRolxModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RoleporModulo]  WITH CHECK ADD  CONSTRAINT [FK_RoleporModulo_Modulo] FOREIGN KEY([IDModulo])
REFERENCES [dbo].[Modulo] ([IDModulo])
GO

ALTER TABLE [dbo].[RoleporModulo] CHECK CONSTRAINT [FK_RoleporModulo_Modulo]
GO

ALTER TABLE [dbo].[RoleporModulo]  WITH CHECK ADD  CONSTRAINT [FK_RoleporModulo_Role] FOREIGN KEY([IDRol])
REFERENCES [dbo].[Role] ([IDRol])
GO

ALTER TABLE [dbo].[RoleporModulo] CHECK CONSTRAINT [FK_RoleporModulo_Role]
GO


