CREATE TABLE [dbo].[Compania](
	[IDCompania] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompania] [nvarchar](250) NOT NULL,
	[IDSiesa] [int] NOT NULL,
	[NombreBD] [nvarchar](250) NOT NULL,
	[NombreConexionBD] [nvarchar](500) NOT NULL,
	[UrlWebServiceSiesa] [nvarchar](max) NOT NULL,
	[UsuarioWebService] [nvarchar](250) NOT NULL,
	[ClaveWebService] [nvarchar](500) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Compania] PRIMARY KEY CLUSTERED 
(
	[IDCompania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
