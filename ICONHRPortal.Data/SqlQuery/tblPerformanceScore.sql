USE [ICONHR]
GO

ALTER TABLE [dbo].[tblPerformanceScore] DROP CONSTRAINT [FK_tblPerformaceScoreTable_tblPerformanceReviewSettings]
GO

/****** Object:  Table [dbo].[tblPerformanceScore]    Script Date: 08/17/2019 2:54:39 AM ******/
DROP TABLE [dbo].[tblPerformanceScore]
GO

/****** Object:  Table [dbo].[tblPerformanceScore]    Script Date: 08/17/2019 2:54:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblPerformanceScore](
	[ScoreID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceReviewID] [int] NOT NULL,
	[RatingValue] [int] NULL,
	[RatingDescription] [text] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblPerfo_7DD229F1A59D32F8] PRIMARY KEY CLUSTERED 
(
	[ScoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblPerformanceScore]  WITH CHECK ADD  CONSTRAINT [FK_tblPerformaceScoreTable_tblPerformanceReviewSettings] FOREIGN KEY([PerformanceReviewID])
REFERENCES [dbo].[tblPerformanceReviewSettings] ([PerformanceReviewID])
GO

ALTER TABLE [dbo].[tblPerformanceScore] CHECK CONSTRAINT [FK_tblPerformaceScoreTable_tblPerformanceReviewSettings]
GO


