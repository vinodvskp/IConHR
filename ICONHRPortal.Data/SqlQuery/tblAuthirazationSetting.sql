USE [ICONHR]
GO

/****** Object:  Table [dbo].[tblAuthorisationRuleSettings]    Script Date: 20-Aug-2019 22:21:47 ******/
DROP TABLE [dbo].[tblAuthorisationRuleSettings]
GO

/****** Object:  Table [dbo].[tblAuthorisationRuleSettings]    Script Date: 20-Aug-2019 22:21:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblAuthorisationRuleSettings](
	[AuthorisationRuleSettingsID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[InUse] [bit] NULL,
	[RuleName] [varchar](100) NULL,
	[LocationID] [nvarchar](500) NULL,
	[LocationName] [nvarchar](1000) NULL,
	[DepartmentID] [nvarchar](500) NULL,
	[DepartmentName] [nvarchar](1000) NULL,
	[JobRoleID] [nvarchar](500) NULL,
	[JobRoleName] [nvarchar](500) NULL,
	[EmploymentTypeID] [nvarchar](500) NULL,
	[EmploymentTypeName] [nvarchar](1000) NULL,
	[SpecificEmployeeID] [nvarchar](1000) NULL,
	[SpecificEmployeeName] [nvarchar](max) NULL,
	[ExcludeEmployeeID] [nvarchar](1000) NULL,
	[ExcludeEmployeeName] [nvarchar](max) NULL,
	[ApproverID] [nvarchar](1000) NULL,
	[ApproverName] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tblAuthorisationRuleSettings] PRIMARY KEY CLUSTERED 
(
	[AuthorisationRuleSettingsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


