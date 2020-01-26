
CREATE TRIGGER Emp_adminstatorSetting_TRG ON   dbo.tblEmployeeDetails
-----------------------------------------------------------------
-----------------------------------------------------------------
--CREATE DATE : 10/13/2019
--AUTHER : CHANDRA GADDE
--DESCRIPTION: This trigger will insert trail  register employee as
--by default adminstrator in administrator setting table.
----------------------------------------------------------------
----------------------------------------------------------------
FOR INSERT
AS  

DECLARE @CompanyURL varchar (150)= (SELECT CompanyURL
    FROM inserted)

IF(@CompanyURL <> NULL  or @CompanyURL <> '')
BEGIN

INSERT INTO tblAdministratorSettings (CompanyID,AssignedEmployeeID, CreatedDate,UpdateDate)
SELECT CompanyID,EmpID,GETDATE(),NULL  FROM inserted
END

select * from [dbo].[tblAdministratorSettings]