USE [ICONHR]
GO

ALTER TABLE [dbo].[tblEmployeeDetails] DROP CONSTRAINT [FK_tblEmployeeDetails_tblCompanyDetails]
GO

ALTER TABLE [dbo].[tblEmployeeDetails] DROP CONSTRAINT [FK_tblEmployeeDetails_lkpEmployeeRoles]
GO

ALTER TABLE [dbo].[tblEmployeeDetails] DROP CONSTRAINT [FK_tblEmployeeDetails_lkpCountry]
GO

/****** Object:  Table [dbo].[tblEmployeeDetails]    Script Date: 10/13/2019 9:52:56 PM ******/
DROP TABLE [dbo].[tblEmployeeDetails]
GO

/****** Object:  Table [dbo].[tblEmployeeDetails]    Script Date: 10/13/2019 9:52:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployeeDetails](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [nvarchar](100) NULL,
	[EmpRoleID] [int] NULL,
	[CompanyID] [int] NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailID] [nvarchar](50) NULL,
	[CompanyUrl] [nvarchar](350) NULL,
	[Location] [nvarchar](50) NULL,
	[PasswordSalt] [nvarchar](100) NULL,
	[PasswordHash] [nvarchar](100) NULL,
	[PasswordToken] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](100) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
	[Gender] [nvarchar](10) NULL,
	[DateOfBirth] [date] NULL,
	[ProfilePhoto] [image] NULL,
	[FileName] [nvarchar](200) NULL,
	[Address] [nvarchar](300) NULL,
	[CountryID] [int] NULL,
	[PostalCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_EmployeeDetails] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblEmployeeDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeeDetails_lkpCountry] FOREIGN KEY([CountryID])
REFERENCES [dbo].[lkpCountry] ([CountryID])
GO

ALTER TABLE [dbo].[tblEmployeeDetails] CHECK CONSTRAINT [FK_tblEmployeeDetails_lkpCountry]
GO

ALTER TABLE [dbo].[tblEmployeeDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeeDetails_lkpEmployeeRoles] FOREIGN KEY([EmpRoleID])
REFERENCES [dbo].[lkpEmployeeRoles] ([EmpRoleID])
GO

ALTER TABLE [dbo].[tblEmployeeDetails] CHECK CONSTRAINT [FK_tblEmployeeDetails_lkpEmployeeRoles]
GO

ALTER TABLE [dbo].[tblEmployeeDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployeeDetails_tblCompanyDetails] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[tblCompanyDetails] ([CompanyID])
GO

ALTER TABLE [dbo].[tblEmployeeDetails] CHECK CONSTRAINT [FK_tblEmployeeDetails_tblCompanyDetails]
GO


