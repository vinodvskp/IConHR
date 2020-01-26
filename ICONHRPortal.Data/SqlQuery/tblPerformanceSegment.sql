USE [ICONHR]
GO

ALTER TABLE [dbo].[tblPerformanceSegment] DROP CONSTRAINT [FK_tblPerformanceSegment_tblPerformanceReviewSettings]
GO

/****** Object:  Table [dbo].[tblPerformanceSegment]    Script Date: 08/17/2019 2:55:17 AM ******/
DROP TABLE [dbo].[tblPerformanceSegment]
GO

/****** Object:  Table [dbo].[tblPerformanceSegment]    Script Date: 08/17/2019 2:55:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblPerformanceSegment](
	[PerformanceSegmentID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceReviewID] [int] NULL,
	[SegmentName] [varchar](100) NULL,
	[SegmentDescription] [text] NULL,
	[Status] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PerformanceSegmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [U_Segment] UNIQUE NONCLUSTERED 
(
	[PerformanceReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[tblPerformanceSegment]  WITH CHECK ADD  CONSTRAINT [FK_tblPerformanceSegment_tblPerformanceReviewSettings] FOREIGN KEY([PerformanceReviewID])
REFERENCES [dbo].[tblPerformanceReviewSettings] ([PerformanceReviewID])
GO

ALTER TABLE [dbo].[tblPerformanceSegment] CHECK CONSTRAINT [FK_tblPerformanceSegment_tblPerformanceReviewSettings]
GO


