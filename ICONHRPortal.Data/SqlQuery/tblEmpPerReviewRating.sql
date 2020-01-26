USE [ICONHR]
GO

ALTER TABLE [dbo].[tblEmpPerReviewRating] DROP CONSTRAINT [FK_tblEmpMgrPerReviewRating_tblPerformaceSegmentQuestions]
GO

ALTER TABLE [dbo].[tblEmpPerReviewRating] DROP CONSTRAINT [FK_tblEmpMgrPerReviewRating_tblEmpMgrPerReviewSegment]
GO

/****** Object:  Table [dbo].[tblEmpPerReviewRating]    Script Date: 09/08/2019 1:15:11 AM ******/
DROP TABLE [dbo].[tblEmpPerReviewRating]
GO

/****** Object:  Table [dbo].[tblEmpPerReviewRating]    Script Date: 09/08/2019 1:15:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmpPerReviewRating](
	[EmpPerReviewRatingID] [int] IDENTITY(1,1) NOT NULL,
	[EmpReviewSegmentID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[ScoreID] [int] NULL,
	[Answer] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblEmp_Mgr_Question_Score_Perf_Review] PRIMARY KEY CLUSTERED 
(
	[EmpPerReviewRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblEmpPerReviewRating]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpMgrPerReviewRating_tblEmpMgrPerReviewSegment] FOREIGN KEY([EmpReviewSegmentID])
REFERENCES [dbo].[tblEmpPerReviewSegment] ([EmpReviewSegmentID])
GO

ALTER TABLE [dbo].[tblEmpPerReviewRating] CHECK CONSTRAINT [FK_tblEmpMgrPerReviewRating_tblEmpMgrPerReviewSegment]
GO

ALTER TABLE [dbo].[tblEmpPerReviewRating]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpMgrPerReviewRating_tblPerformaceSegmentQuestions] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[tblPerformaceSegmentQuestions] ([PerformanceQuestionID])
GO

ALTER TABLE [dbo].[tblEmpPerReviewRating] CHECK CONSTRAINT [FK_tblEmpMgrPerReviewRating_tblPerformaceSegmentQuestions]
GO


