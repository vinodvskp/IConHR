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
   public class PlannerRepository : GenericRepository<tblPlanner>, IPlannerRepository
    {
        public PlannerRepository(ICONHRContext context) : base(context)
        {

        }

        public int GetDepartmentIdByEmployeeId(int employeeId)
        {
            var department = (from employee in _IconhrContext.EmployeeDetails
                join jobDetail in _IconhrContext.EmployeeJobDetails
                    on employee.EmpID equals jobDetail.EmpID
                join dept in _IconhrContext.Departments on jobDetail.DeptID equals dept.DeptID
                where employee.EmpID == employeeId
                select dept).FirstOrDefault();
            if (department != null)
            {
              return  department.DeptID;
            }

            return 0;
        }

        public long GetLocationByEmployeeId(int employeeId)
        {
            var location = (from employee in _IconhrContext.EmployeeDetails
                join jobDetail in _IconhrContext.EmployeeJobDetails
                    on employee.EmpID equals jobDetail.EmpID
                join loc in _IconhrContext.Locations on jobDetail.LocationID equals loc.LocationId
                where employee.EmpID == employeeId
                select loc).FirstOrDefault();
            if (location != null)
            {
                return location.LocationId;
            }

            return 0;
        }

        public PlannerFilterModel GetFilterOptions()
        {
            var data = (from loc in _IconhrContext.Locations
                join plns in _IconhrContext.Planners on loc.LocationId equals plns.LocationId
                group new {loc, plns} by new {loc.LocationId, loc.Location}
                into gp
                select new ChoiceOptionModel() {id = gp.Key.LocationId, text = gp.Key.Location}).ToList();


            return new PlannerFilterModel
            {
                DepartmentOptions = (from dept in  _IconhrContext.Departments join pln in _IconhrContext.Planners on dept.DeptID equals pln.DepartmentId group new {dept,pln}  by new {dept.DeptID, dept.DeptName } into gp select new ChoiceOptionModel() { id = gp.Key.DeptID ,text = gp.Key.DeptName}).ToList(),
                LocationOptions = (from loc in _IconhrContext.Locations join plns in _IconhrContext.Planners on loc.LocationId equals plns.LocationId group new {loc,plns}  by new {loc.LocationId, loc.Location } into gp select new ChoiceOptionModel() { id = gp.Key.LocationId, text = gp.Key.Location}).ToList(),
                EmployeeOptions = (from emp in _IconhrContext.EmployeeDetails join pln in _IconhrContext.Planners on emp.EmpID equals pln.EmpID group new {emp,pln}  by new {emp.EmpID, emp.EmpName } into gp select new ChoiceOptionModel() { id = gp.Key.EmpID ,text = gp.Key.EmpName}).ToList(),
            };
        }
    }
}
