USE [ICONHR]
GO

ALTER TABLE [dbo].[tblMgrPerReviewPerformance] DROP CONSTRAINT [FK_tblMgrPerReviewPerformance_tblPerformanceReviewSettings]
GO

ALTER TABLE [dbo].[tblMgrPerReviewPerformance] DROP CONSTRAINT [FK_tblMgrPerReviewPerformance_tblEmployeeDetails]
GO

/****** Object:  Table [dbo].[tblMgrPerReviewPerformance]    Script Date: 09/08/2019 1:11:05 AM ******/
DROP TABLE [dbo].[tblMgrPerReviewPerformance]
GO

/****** Object:  Table [dbo].[tblMgrPerReviewPerformance]    Script Date: 09/08/2019 1:11:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblMgrPerReviewPerformance](
	[MgrReviewID] [int] IDENTITY(1,1) NOT NULL,
	[RepMgrID] [int] NULL,
	[EmpID] [int] NULL,
	[PerformanceReviewID] [int] NOT NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDate] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblMgrPerReviewPerformance] PRIMARY KEY CLUSTERED 
(
	[MgrReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblMgrPerReviewPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblMgrPerReviewPerformance_tblEmployeeDetails] FOREIGN KEY([EmpID])
REFERENCES [dbo].[tblEmployeeDetails] ([EmpID])
GO

ALTER TABLE [dbo].[tblMgrPerReviewPerformance] CHECK CONSTRAINT [FK_tblMgrPerReviewPerformance_tblEmployeeDetails]
GO

ALTER TABLE [dbo].[tblMgrPerReviewPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblMgrPerReviewPerformance_tblPerformanceReviewSettings] FOREIGN KEY([PerformanceReviewID])
REFERENCES [dbo].[tblPerformanceReviewSettings] ([PerformanceReviewID])
GO

ALTER TABLE [dbo].[tblMgrPerReviewPerformance] CHECK CONSTRAINT [FK_tblMgrPerReviewPerformance_tblPerformanceReviewSettings]
GO


