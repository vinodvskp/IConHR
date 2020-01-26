USE [ICONHR]
GO

/****** Object:  Table [dbo].[tblPerformanceReviewSettings]    Script Date: 08/17/2019 2:52:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblPerformanceReviewSettings](
	[PerformanceReviewID] [int] IDENTITY(1,1) NOT NULL,
	[ReviewTitle] [varchar](100) NULL,
	[ReviewCompletionDate] [datetime] NULL,
	[CompanyID] [int] NULL,
	[LocationID] [bigint] NULL,
	[DepartmentID] [int] NULL,
	[JobRoleID] [int] NULL,
	[EmploymentTypeID] [int] NULL,
	[LengthOfService] [int] NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](100) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PerformanceReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings]  WITH CHECK ADD  CONSTRAINT [FK_tblPerformanceReviewSettings_lkpDepartments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[lkpDepartments] ([DeptID])
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings] CHECK CONSTRAINT [FK_tblPerformanceReviewSettings_lkpDepartments]
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings]  WITH CHECK ADD  CONSTRAINT [FK_tblPerformanceReviewSettings_lkpEmploymentType] FOREIGN KEY([EmploymentTypeID])
REFERENCES [dbo].[lkpEmploymentType] ([EmploymentTypeID])
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings] CHECK CONSTRAINT [FK_tblPerformanceReviewSettings_lkpEmploymentType]
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings]  WITH CHECK ADD  CONSTRAINT [FK_tblPerformanceReviewSettings_lkpLocation] FOREIGN KEY([LocationID])
REFERENCES [dbo].[lkpLocation] ([LocationId])
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings] CHECK CONSTRAINT [FK_tblPerformanceReviewSettings_lkpLocation]
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings]  WITH CHECK ADD  CONSTRAINT [FK_tblPerformanceReviewSettings_tblCompanyDetails] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[tblCompanyDetails] ([CompanyID])
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings] CHECK CONSTRAINT [FK_tblPerformanceReviewSettings_tblCompanyDetails]
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings]  WITH CHECK ADD  CONSTRAINT [FK_tblPerformanceReviewSettings_tblJobRoles] FOREIGN KEY([JobRoleID])
REFERENCES [dbo].[tblJobRoles] ([JobRoleID])
GO

ALTER TABLE [dbo].[tblPerformanceReviewSettings] CHECK CONSTRAINT [FK_tblPerformanceReviewSettings_tblJobRoles]
GO


