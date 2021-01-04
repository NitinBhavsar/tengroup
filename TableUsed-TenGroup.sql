USE [ten]
GO

/****** Object:  Table [dbo].[client]    Script Date: 04/01/2021 7:01:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[client](
	[schemeId] [nvarchar](50) NULL,
	[firstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL
) ON [PRIMARY]

GO


