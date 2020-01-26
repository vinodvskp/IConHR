using ICONHRPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Model;

namespace ICONHRPortal.Data.IRepository
{
    public interface IPlannerRepository : IGenericRepository<tblPlanner>
    {
       int GetDepartmentIdByEmployeeId(int employeeId);
        PlannerFilterModel GetFilterOptions();
        long GetLocationByEmployeeId(int employeeId);
    }
}
