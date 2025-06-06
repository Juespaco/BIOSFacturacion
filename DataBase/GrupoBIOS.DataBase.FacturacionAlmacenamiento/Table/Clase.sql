﻿CREATE TABLE [dbo].[Clase](
	[IDClase] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](250) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Clase] PRIMARY KEY CLUSTERED 
(
	[IDClase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO