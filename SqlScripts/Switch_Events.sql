USE [Portnox]
GO

/****** Object:  Table [dbo].[Switch_Events]    Script Date: 1/14/2021 10:14:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Switch_Events](
	[Event_Id] [int] NOT NULL,
	[Switch_Ip] [nvarchar](20) NOT NULL,
	[Port_Id] [int] NOT NULL,
	[Device_Mac] [nvarchar](50) NULL
) ON [PRIMARY]
GO


