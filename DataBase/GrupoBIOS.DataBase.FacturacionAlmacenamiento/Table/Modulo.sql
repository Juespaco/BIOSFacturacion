﻿CREATE TABLE [dbo].[Modulo](
	[IDModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [nvarchar](150) NOT NULL,
	[Observacion] [nvarchar](max) NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[IDModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO