USE [ICONHR]
GO

/****** Object:  Table [dbo].[tblEmployeePerformance]    Script Date: 17-Aug-2019 13:15:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployeePerformance](
	[EmployeePerformanceID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NOT NULL,
	[PerformanceReviewID] [int] NOT NULL,
	[PerformanceSegmentID] [int] NOT NULL,
	[ScoreID] [int] NOT NULL,
	[PerformanceQuestionID] [int] NOT NULL,
	[Answer] [text] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDate] [date] NULL,
 CONSTRAINT [PK_tblEmployeePerformance] PRIMARY KEY CLUSTERED 
(
	[EmployeePerformanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblEmployeePerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeePerformance_tblEmployeeDetails] FOREIGN KEY([EmpID])
REFERENCES [dbo].[tblEmployeeDetails] ([EmpID])
GO

ALTER TABLE [dbo].[tblEmployeePerformance] CHECK CONSTRAINT [FK_tblEmployeePerformance_tblEmployeeDetails]
GO

ALTER TABLE [dbo].[tblEmployeePerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeePerformance_tblPerformaceSegmentQuestions] FOREIGN KEY([PerformanceQuestionID])
REFERENCES [dbo].[tblPerformaceSegmentQuestions] ([PerformanceQuestionID])
GO

ALTER TABLE [dbo].[tblEmployeePerformance] CHECK CONSTRAINT [FK_tblEmployeePerformance_tblPerformaceSegmentQuestions]
GO

ALTER TABLE [dbo].[tblEmployeePerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeePerformance_tblPerformanceReviewSettings] FOREIGN KEY([PerformanceReviewID])
REFERENCES [dbo].[tblPerformanceReviewSettings] ([PerformanceReviewID])
GO

ALTER TABLE [dbo].[tblEmployeePerformance] CHECK CONSTRAINT [FK_tblEmployeePerformance_tblPerformanceReviewSettings]
GO

ALTER TABLE [dbo].[tblEmployeePerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeePerformance_tblPerformanceScore] FOREIGN KEY([ScoreID])
REFERENCES [dbo].[tblPerformanceScore] ([ScoreID])
GO

ALTER TABLE [dbo].[tblEmployeePerformance] CHECK CONSTRAINT [FK_tblEmployeePerformance_tblPerformanceScore]
GO

ALTER TABLE [dbo].[tblEmployeePerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeePerformance_tblPerformanceSegment] FOREIGN KEY([PerformanceSegmentID])
REFERENCES [dbo].[tblPerformanceSegment] ([PerformanceSegmentID])
GO

ALTER TABLE [dbo].[tblEmployeePerformance] CHECK CONSTRAINT [FK_tblEmployeePerformance_tblPerformanceSegment]
GO


