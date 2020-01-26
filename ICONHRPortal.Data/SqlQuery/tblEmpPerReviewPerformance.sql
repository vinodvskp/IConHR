USE [ICONHR]
GO

ALTER TABLE [dbo].[tblEmpPerReviewPerformance] DROP CONSTRAINT [FK_tblEmpMgrPerReviewPerformance_tblPerformanceReviewSettings]
GO

ALTER TABLE [dbo].[tblEmpPerReviewPerformance] DROP CONSTRAINT [FK_tblEmpMgrPerReviewPerformance_tblEmployeeDetails]
GO

/****** Object:  Table [dbo].[tblEmpPerReviewPerformance]    Script Date: 09/08/2019 1:13:24 AM ******/
DROP TABLE [dbo].[tblEmpPerReviewPerformance]
GO

/****** Object:  Table [dbo].[tblEmpPerReviewPerformance]    Script Date: 09/08/2019 1:13:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmpPerReviewPerformance](
	[EmpReviewID] [int] IDENTITY(1,1) NOT NULL,
	[RepMgrID] [int] NULL,
	[EmpID] [int] NULL,
	[PerformanceReviewID] [int] NOT NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDate] [date] NULL,
	[Status] [bit] NULL,
	[SharetoManager] [bit] NULL,
 CONSTRAINT [PK__tblEmplo__594318CCC462B8BB] PRIMARY KEY CLUSTERED 
(
	[EmpReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblEmpPerReviewPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpMgrPerReviewPerformance_tblEmployeeDetails] FOREIGN KEY([EmpID])
REFERENCES [dbo].[tblEmployeeDetails] ([EmpID])
GO

ALTER TABLE [dbo].[tblEmpPerReviewPerformance] CHECK CONSTRAINT [FK_tblEmpMgrPerReviewPerformance_tblEmployeeDetails]
GO

ALTER TABLE [dbo].[tblEmpPerReviewPerformance]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpMgrPerReviewPerformance_tblPerformanceReviewSettings] FOREIGN KEY([PerformanceReviewID])
REFERENCES [dbo].[tblPerformanceReviewSettings] ([PerformanceReviewID])
GO

ALTER TABLE [dbo].[tblEmpPerReviewPerformance] CHECK CONSTRAINT [FK_tblEmpMgrPerReviewPerformance_tblPerformanceReviewSettings]
GO


