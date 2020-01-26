USE [ICONHR]
GO

/****** Object:  Table [dbo].[lkpEmploymentType]    Script Date: 08/17/2019 12:43:24 AM ******/
DROP TABLE [dbo].[lkpEmploymentType]
GO

/****** Object:  Table [dbo].[lkpEmploymentType]    Script Date: 08/17/2019 12:43:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[lkpEmploymentType](
	[EmploymentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentTypeDesc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_lkpEmploymentType] PRIMARY KEY CLUSTERED 
(
	[EmploymentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


insert into lkpEmploymentType values('Casual');
insert into lkpEmploymentType values('Contractor');
insert into lkpEmploymentType values('Fixed Term');
insert into lkpEmploymentType values('Full Time');
insert into lkpEmploymentType values('Part Time');
insert into lkpEmploymentType values('Temporary');