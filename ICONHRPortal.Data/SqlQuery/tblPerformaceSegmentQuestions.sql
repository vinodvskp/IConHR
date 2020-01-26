USE [ICONHR]
GO

ALTER TABLE [dbo].[tblPerformaceSegmentQuestions] DROP CONSTRAINT [FK_tblPerformaceSegmentQuestions_tblPerformanceSegment]
GO

/****** Object:  Table [dbo].[tblPerformaceSegmentQuestions]    Script Date: 08/17/2019 2:54:02 AM ******/
DROP TABLE [dbo].[tblPerformaceSegmentQuestions]
GO

/****** Object:  Table [dbo].[tblPerformaceSegmentQuestions]    Script Date: 08/17/2019 2:54:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblPerformaceSegmentQuestions](
	[PerformanceQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceSegmentID] [int] NULL,
	[Question] [text] NULL,
	[HelpText] [text] NULL,
	[Status] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDate] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblPerformaceSegmentQuestions]  WITH CHECK ADD  CONSTRAINT [FK_tblPerformaceSegmentQuestions_tblPerformanceSegment] FOREIGN KEY([PerformanceSegmentID])
REFERENCES [dbo].[tblPerformanceSegment] ([PerformanceSegmentID])
GO

ALTER TABLE [dbo].[tblPerformaceSegmentQuestions] CHECK CONSTRAINT [FK_tblPerformaceSegmentQuestions_tblPerformanceSegment]
GO


