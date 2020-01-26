Create Procedure  GetAdministratorSettings_sp(@pAs_CompanyID int)
-----------------------------------------------------------------
-----------------------------------------------------------------
--CREATE DATE : 10/13/2019
--AUTHER : CHANDRA GADDE
--DESCRIPTION: THIS PROCEDURE WILL RETURNS THE ADMINISTRATOR DETAILS
--BASED ON COMPANY WITH RESPECT TO ALL DEPT,LOCTION,JOBROLE,EMPLOYMENT TYPE

--Parameter : CompanyId

--EXEC  GetAdministratorSettings_sp

----------------------------------------------------------------
----------------------------------------------------------------
AS
BEGIN

SELECT   EMP.EmpID as AssignedEmployeeID,EMP.EmpName as AssignedEmployeeName,DETAILS.Location,DETAILS.DeptName as Department,DETAILS.EmploymentTypeDesc , 
DETAILS.EmpRole as JobRole, EMP.CompanyID FROM tblEmployeeDetails EMP
 INNER JOIN  tblAdministratorSettings ADSETTING ON EMP.EmpID =ADSETTING.AssignedEmployeeID
LEFT JOIN
(SELECT EJOB.EmpID, LOC.Location, DEPT.DeptName,EROLE.EmpRole, ETYPE.EmploymentTypeDesc FROM tblEmployeeJobDetails  EJOB

 LEFT JOIN lkpLocation LOC ON  LOC.LocationId =EJOB.LocationID
 
 LEFT JOIN lkpDepartments DEPT ON DEPT.DeptID=EJOB.DeptID
 LEFT JOIN lkpEmployeeRoles EROLE ON EROLE.EmpRoleID=EJOB.JobRoleID
 LEFT JOIN lkpEmploymentType ETYPE ON ETYPE.EmploymentTypeID=EJOB.JobTypeID) DETAILS ON DETAILS.EmpID=EMP.EmpID  WHERE EMP.CompanyID=@pAs_CompanyID
END