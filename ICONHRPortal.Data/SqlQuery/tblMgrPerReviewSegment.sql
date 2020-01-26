USE [ICONHR]
GO

ALTER TABLE [dbo].[tblMgrPerReviewSegment] DROP CONSTRAINT [FK_tblMgrPerReviewSegment_tblMgrPerReviewPerformance]
GO

/****** Object:  Table [dbo].[tblMgrPerReviewSegment]    Script Date: 09/08/2019 1:12:34 AM ******/
DROP TABLE [dbo].[tblMgrPerReviewSegment]
GO

/****** Object:  Table [dbo].[tblMgrPerReviewSegment]    Script Date: 09/08/2019 1:12:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblMgrPerReviewSegment](
	[MgrReviewSegmentID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceSegmentID] [int] NOT NULL,
	[MgrReviewID] [int] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblMgrPerReviewSegment] PRIMARY KEY CLUSTERED 
(
	[MgrReviewSegmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblMgrPerReviewSegment]  WITH CHECK ADD  CONSTRAINT [FK_tblMgrPerReviewSegment_tblMgrPerReviewPerformance] FOREIGN KEY([MgrReviewID])
REFERENCES [dbo].[tblMgrPerReviewPerformance] ([MgrReviewID])
GO

ALTER TABLE [dbo].[tblMgrPerReviewSegment] CHECK CONSTRAINT [FK_tblMgrPerReviewSegment_tblMgrPerReviewPerformance]
GO


