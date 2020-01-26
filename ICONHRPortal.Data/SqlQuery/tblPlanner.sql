USE [ICONHR]
GO

ALTER TABLE [dbo].[tblPlanner] DROP CONSTRAINT [FK_tblPlanner_lkpPlannerCategoryType]
GO

ALTER TABLE [dbo].[tblPlanner] DROP CONSTRAINT [FK_tblPlanner_lkpLocation]
GO

ALTER TABLE [dbo].[tblPlanner] DROP CONSTRAINT [FK_tblPlanner_lkpDepartments]
GO

/****** Object:  Table [dbo].[tblPlanner]    Script Date: 08/08/2019 11:41:53 PM ******/
DROP TABLE [dbo].[tblPlanner]
GO

/****** Object:  Table [dbo].[tblPlanner]    Script Date: 08/08/2019 11:41:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblPlanner](
	[PlannerID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NULL,
	[DepartmentId] [int] NULL,
	[LocationId] [bigint] NULL,
	[PlannedEventName] [varchar](100) NULL,
	[PlannerCategoryID] [int] NULL,
	[PlannedDate] [datetime] NULL,
	[CreatedBy] [nchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nchar](100) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK__tblPlann__B1492A2B00141BCB] PRIMARY KEY CLUSTERED 
(
	[PlannerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[tblPlanner]  WITH CHECK ADD  CONSTRAINT [FK_tblPlanner_lkpDepartments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[lkpDepartments] ([DeptID])
GO

ALTER TABLE [dbo].[tblPlanner] CHECK CONSTRAINT [FK_tblPlanner_lkpDepartments]
GO

ALTER TABLE [dbo].[tblPlanner]  WITH CHECK ADD  CONSTRAINT [FK_tblPlanner_lkpLocation] FOREIGN KEY([LocationId])
REFERENCES [dbo].[lkpLocation] ([LocationId])
GO

ALTER TABLE [dbo].[tblPlanner] CHECK CONSTRAINT [FK_tblPlanner_lkpLocation]
GO

ALTER TABLE [dbo].[tblPlanner]  WITH CHECK ADD  CONSTRAINT [FK_tblPlanner_lkpPlannerCategoryType] FOREIGN KEY([PlannerCategoryID])
REFERENCES [dbo].[lkpPlannerCategoryType] ([PlannerCategoryID])
GO

ALTER TABLE [dbo].[tblPlanner] CHECK CONSTRAINT [FK_tblPlanner_lkpPlannerCategoryType]
GO


