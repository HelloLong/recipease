USE [INFO3420_12]
GO

/****** Object:  Table [dbo].[RECIPEASE_PANTRY_TYPE]    Script Date: 11/21/2011 17:19:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RECIPEASE_PANTRY_TYPE](
	[pantry_type_id] [int] IDENTITY(1,1) NOT NULL,
	[pantry_type_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RECIPEASE_PANTRY_TYPE] PRIMARY KEY CLUSTERED 
(
	[pantry_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

