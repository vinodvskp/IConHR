using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6.BulkInsert;
using EF6.BulkInsert.Extensions;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using EntityFramework.MappingAPI.Extensions;
using ICONHRPortal.Model;

namespace ICONHRPortal.Data.Repository
{
   public class EmployeeDetailsRepository : GenericRepository<tblEmployeeDetail>, IEmployeeDetailsRepository
    {
        public EmployeeDetailsRepository(ICONHRContext context) : base(context)
        {

        }
        public tblEmployeeDetail GetEmployeeDetail(long id)
        {
            return _IconhrContext.EmployeeDetails.Where(x => x.EmpID == id).FirstOrDefault();
        }
        public EmployeeDetailsModel GetEmployee(long id)
        {
            var objEmployee = _IconhrContext.EmployeeDetails.Where(x => x.EmpID == id).Select(empDetails => new EmployeeDetailsModel
            {
                EmailID = empDetails.EmailID,
                PhoneNumber=empDetails.PhoneNumber,
                EmpName=empDetails.EmpName,
                EmpID=empDetails.EmpID,
                ContractedHours = empDetails.tblEmployeeJobDetails.FirstOrDefault().ContractedHours,
                EmpStartDate = empDetails.tblEmployeeJobDetails.FirstOrDefault().EmpStartDate,
                LocationName = empDetails.tblEmployeeJobDetails.FirstOrDefault().lkpLocation.Location,
                DeptName = empDetails.tblEmployeeJobDetails.FirstOrDefault().lkpDepartment.DeptName,
            }).FirstOrDefault();
            return objEmployee;
        }
        
    
        public IEnumerable<EmployeeDetailsModel> GetEmployeeDetails(int? mgrId)
        {

            var objEmployee = _IconhrContext.EmployeeDetails.Select(empDetails => new EmployeeDetailsModel
            {
                EmailID = empDetails.EmailID,
                PhoneNumber = empDetails.PhoneNumber,
                EmpName = empDetails.EmpName,
                EmpID = empDetails.EmpID,
                ContractedHours = empDetails.tblEmployeeJobDetails.FirstOrDefault().ContractedHours,
                EmpStartDate = empDetails.tblEmployeeJobDetails.FirstOrDefault().EmpStartDate,
                LocationName = empDetails.tblEmployeeJobDetails.FirstOrDefault().lkpLocation.Location,
                DeptName = empDetails.tblEmployeeJobDetails.FirstOrDefault().lkpDepartment.DeptName,
                DeptID= empDetails.tblEmployeeJobDetails.FirstOrDefault().lkpDepartment.DeptID,
                JobRoleName = _IconhrContext.JobRoles.Where(c => c.JobRoleID == empDetails.tblEmployeeJobDetails.FirstOrDefault().JobRoleID).FirstOrDefault().JobRole,
                JobRoleID = _IconhrContext.JobRoles.Where(c => c.JobRoleID == empDetails.tblEmployeeJobDetails.FirstOrDefault().JobRoleID).FirstOrDefault().JobRoleID,
            }).ToList();
            return objEmployee;
            //return from employee in _IconhrContext.EmployeeDetails
            //    join jobDetails in _IconhrContext.EmployeeJobDetails on employee.EmpID equals jobDetails.EmpID
            //    join companyDetail in _IconhrContext.CompanyDetails on employee.CompanyID equals companyDetail.CompanyID
            //        into companyDetailLeft

            //    from company in companyDetailLeft.DefaultIfEmpty()
            //    join role in _IconhrContext.EmployeeRoles on employee.EmpRoleID equals role.EmpRoleID into
            //        employeeRoleLeft
            //    from empRole in employeeRoleLeft.DefaultIfEmpty()
            //    join country in _IconhrContext.Countries on employee.CountryID equals country.CountryID into
            //        countryDetailLeft
            //    from ctry in countryDetailLeft.DefaultIfEmpty()
            //  //  where jobDetails.RepMgrID == mgrId
            //       select new EmployeeDetailsModel()
            //    {
            //        EmpID = employee.EmpID,
            //        EmpName = employee.EmpName,
            //        EmpRoleID = employee.EmpRoleID,
            //        CompanyID = employee.CompanyID,
            //        PhoneNumber = employee.PhoneNumber,
            //        EmpRole = empRole.EmpRole,
            //        CountryName = ctry.CountryName,
            //        CompanyName = company.CompanyName,
            //        EmailID = employee.EmailID,
            //        PasswordSalt = employee.PasswordSalt,
            //        PasswordHash = employee.PasswordHash,
            //        PasswordToken = employee.PasswordToken,
            //        Status = employee.Status,
            //        Gender = employee.Gender,
            //        DateOfBirth = employee.DateOfBirth,
            //        ProfilePhoto = employee.ProfilePhoto,
            //        Address = employee.Address,
            //        PostalCode = employee.PostalCode,
            //        JobRoleName= _IconhrContext.JobRoles.Where(c=>c.JobRoleID== jobDetails.JobRoleID).FirstOrDefault().JobRole,
            //        LocationName= _IconhrContext.Locations.Where(c => c.LocationId == jobDetails.LocationID).FirstOrDefault().Location,
            //       };
        }

        public int SaveBulkEmployees(List<tblEmployeeDetail> employees)
        {
            
            //BulkInsertExtension.BulkInsert(_IconhrContext,employees);
            //_IconhrContext.BulkInsert(employees);
            foreach (var emp in employees)
            {
                _IconhrContext.EmployeeDetails.Add(emp);
            }

            _IconhrContext.SaveChanges();
            return 0;
        }
    }
}
