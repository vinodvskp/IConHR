USE [ICONHR]
GO

ALTER TABLE [dbo].[tblEmpPerReviewSegment] DROP CONSTRAINT [FK_tblEmpMgrPerReviewSegment_tblEmpMgrPerReviewPerformance]
GO

ALTER TABLE [dbo].[tblEmpPerReviewSegment] DROP CONSTRAINT [FK_tblEmp_Mgr_Per_Review_Segment_tblPerformanceSegment]
GO

/****** Object:  Table [dbo].[tblEmpPerReviewSegment]    Script Date: 09/08/2019 1:14:35 AM ******/
DROP TABLE [dbo].[tblEmpPerReviewSegment]
GO

/****** Object:  Table [dbo].[tblEmpPerReviewSegment]    Script Date: 09/08/2019 1:14:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmpPerReviewSegment](
	[EmpReviewSegmentID] [int] IDENTITY(1,1) NOT NULL,
	[SegmentID] [int] NOT NULL,
	[EmpReviewID] [int] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblEmp_Mgr_Per_Review_Segment] PRIMARY KEY CLUSTERED 
(
	[EmpReviewSegmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblEmpPerReviewSegment]  WITH CHECK ADD  CONSTRAINT [FK_tblEmp_Mgr_Per_Review_Segment_tblPerformanceSegment] FOREIGN KEY([SegmentID])
REFERENCES [dbo].[tblPerformanceSegment] ([PerformanceSegmentID])
GO

ALTER TABLE [dbo].[tblEmpPerReviewSegment] CHECK CONSTRAINT [FK_tblEmp_Mgr_Per_Review_Segment_tblPerformanceSegment]
GO

ALTER TABLE [dbo].[tblEmpPerReviewSegment]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpMgrPerReviewSegment_tblEmpMgrPerReviewPerformance] FOREIGN KEY([EmpReviewID])
REFERENCES [dbo].[tblEmpPerReviewPerformance] ([EmpReviewID])
GO

ALTER TABLE [dbo].[tblEmpPerReviewSegment] CHECK CONSTRAINT [FK_tblEmpMgrPerReviewSegment_tblEmpMgrPerReviewPerformance]
GO


