using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.Data.Repository
{
    public class AdministratorSettingRepository : GenericRepository<tblAdministratorSetting>, IAdministratorSettingRepository
    {
        public AdministratorSettingRepository(ICONHRContext context) : base(context)
        {

        }

        public IEnumerable<AdministratorSettingModel> GetAdminSettingDetailsByCompanyId(int id)
        {

            var query = _IconhrContext.Database.SqlQuery<AdministratorSettingModel>(
                "exec GetAdministratorSettings_sp @pAs_CompanyID=" + id).ToList();
            return query;
            //var data = (from emp in _IconhrContext.EmployeeDetails.DefaultIfEmpty()
            //            join adminSetting in _IconhrContext.AdministratorSettings.DefaultIfEmpty() on emp.EmpID equals adminSetting
            //                .AssignedEmployeeID
            //            join role in _IconhrContext.EmployeeRoles on emp.EmpRoleID equals role.EmpRoleID
            //            join jobdetail in _IconhrContext.EmployeeJobDetails on emp.EmpID equals jobdetail.EmpID
            //            join location in _IconhrContext.Locations on jobdetail.LocationID equals location.LocationId
            //            join department in _IconhrContext.Departments on jobdetail.DeptID equals department.DeptID
            //            where adminSetting.CompanyID == id
            //            select new AdministratorSettingModel
            //            {
            //                AssignedEmployeeID = emp.EmpID,
            //                Location = location.Location, //TODO need to join location table
            //                AssignedEmployeeName = emp.EmpName,
            //                JobRole = role.EmpRole,
            //                Department = department.DeptName // TODO need to join lkpDepartment table but no relation


            //            });
            //return data.ToList();
        }

        public IEnumerable<ChoiceOptionModel> GetAdminManagerNames()
        {
            return _IconhrContext.AdministratorSettings.Include("tblEmployeeDetail").Select(x => new ChoiceOptionModel
            {
                id = x.AssignedEmployeeID.Value,
                text = x.tblEmployeeDetail.EmpName
            }).ToList();
        }
    }
}
