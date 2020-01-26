USE [ICONHR]
GO

ALTER TABLE [dbo].[tblMgrPerReviewRating] DROP CONSTRAINT [FK_tblMgrPerReviewRating_tblPerformaceSegmentQuestions]
GO

ALTER TABLE [dbo].[tblMgrPerReviewRating] DROP CONSTRAINT [FK_tblMgrPerReviewRating_tblMgrPerReviewSegment]
GO

/****** Object:  Table [dbo].[tblMgrPerReviewRating]    Script Date: 09/08/2019 1:11:38 AM ******/
DROP TABLE [dbo].[tblMgrPerReviewRating]
GO

/****** Object:  Table [dbo].[tblMgrPerReviewRating]    Script Date: 09/08/2019 1:11:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblMgrPerReviewRating](
	[MgrPerReviewRatingID] [int] IDENTITY(1,1) NOT NULL,
	[MgrReviewSegmentID] [int] NOT NULL,
	[PerformanceQuestionID] [int] NOT NULL,
	[ScoreID] [int] NULL,
	[Answer] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblMgrPerReviewRating] PRIMARY KEY CLUSTERED 
(
	[MgrPerReviewRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblMgrPerReviewRating]  WITH CHECK ADD  CONSTRAINT [FK_tblMgrPerReviewRating_tblMgrPerReviewSegment] FOREIGN KEY([MgrReviewSegmentID])
REFERENCES [dbo].[tblMgrPerReviewSegment] ([MgrReviewSegmentID])
GO

ALTER TABLE [dbo].[tblMgrPerReviewRating] CHECK CONSTRAINT [FK_tblMgrPerReviewRating_tblMgrPerReviewSegment]
GO

ALTER TABLE [dbo].[tblMgrPerReviewRating]  WITH CHECK ADD  CONSTRAINT [FK_tblMgrPerReviewRating_tblPerformaceSegmentQuestions] FOREIGN KEY([PerformanceQuestionID])
REFERENCES [dbo].[tblPerformaceSegmentQuestions] ([PerformanceQuestionID])
GO

ALTER TABLE [dbo].[tblMgrPerReviewRating] CHECK CONSTRAINT [FK_tblMgrPerReviewRating_tblPerformaceSegmentQuestions]
GO


