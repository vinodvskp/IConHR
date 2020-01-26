USE [ICONHR]
GO

/****** Object:  Table [dbo].[tblManagerPerformance]    Script Date: 17-Aug-2019 13:04:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblManagerPerformance](
	[ManagerPerformanceID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NOT NULL,
	[RepMgrID] [int] NOT NULL,
	[PerformanceReviewID] [int] NOT NULL,
	[PerformanceSegmentID] [int] NOT NULL,
	[ScoreID] [int] NOT NULL,
	[PerformanceQuestionID] [int] NOT NULL,
	[Answer] [text] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDate] [date] NULL,
 CONSTRAINT [PK_tblManagerPerformance] PRIMARY KEY CLUSTERED 
(
	[ManagerPerformanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblManagerPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblManagerPerformance_tblEmployeeDetails] FOREIGN KEY([EmpID])
REFERENCES [dbo].[tblEmployeeDetails] ([EmpID])
GO

ALTER TABLE [dbo].[tblManagerPerformance] CHECK CONSTRAINT [FK_tblManagerPerformance_tblEmployeeDetails]
GO


ALTER TABLE [dbo].[tblManagerPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblManagerPerformance_tblEmployeeJobDetails] FOREIGN KEY([RepMgrID])
REFERENCES [dbo].[tblEmployeeJobDetails] ([RepMgrID])
GO

ALTER TABLE [dbo].[tblManagerPerformance] CHECK CONSTRAINT [FK_tblManagerPerformance_tblEmployeeJobDetails]
GO






ALTER TABLE [dbo].[tblManagerPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblManagerPerformance_tblPerformaceSegmentQuestions] FOREIGN KEY([PerformanceQuestionID])
REFERENCES [dbo].[tblPerformaceSegmentQuestions] ([PerformanceQuestionID])
GO

ALTER TABLE [dbo].[tblManagerPerformance] CHECK CONSTRAINT [FK_tblManagerPerformance_tblPerformaceSegmentQuestions]
GO

ALTER TABLE [dbo].[tblManagerPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblManagerPerformance_tblPerformanceReviewSettings] FOREIGN KEY([PerformanceReviewID])
REFERENCES [dbo].[tblPerformanceReviewSettings] ([PerformanceReviewID])
GO

ALTER TABLE [dbo].[tblManagerPerformance] CHECK CONSTRAINT [FK_tblManagerPerformance_tblPerformanceReviewSettings]
GO

ALTER TABLE [dbo].[tblManagerPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblManagerPerformance_tblPerformanceScore] FOREIGN KEY([ScoreID])
REFERENCES [dbo].[tblPerformanceScore] ([ScoreID])
GO

ALTER TABLE [dbo].[tblManagerPerformance] CHECK CONSTRAINT [FK_tblManagerPerformance_tblPerformanceScore]
GO

ALTER TABLE [dbo].[tblManagerPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblManagerPerformance_tblPerformanceSegment] FOREIGN KEY([PerformanceSegmentID])
REFERENCES [dbo].[tblPerformanceSegment] ([PerformanceSegmentID])
GO

ALTER TABLE [dbo].[tblManagerPerformance] CHECK CONSTRAINT [FK_tblManagerPerformance_tblPerformanceSegment]
GO


