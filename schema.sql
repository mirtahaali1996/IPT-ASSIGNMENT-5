USE [IPT]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 15-Jan-21 7:56:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[SeatNo] [varchar](10) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[FatherName] [varchar](25) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Gender] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SeatNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
