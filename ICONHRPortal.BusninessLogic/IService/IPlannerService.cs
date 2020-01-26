using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IPlannerService
    {
        int SavePlanner(PlannerModel model);
        IEnumerable<PlannerModel> GetPlanners();
        int UpdatePlanner(PlannerModel model);
        int DeletePlanner(int id);
        IEnumerable<ChoiceOptionModel> GetPlannerType();
        int GetDepartmentId(int employeeId);
        PlannerFilterModel GetFilterOptions();
        long GetLocationByEmployeeId(int employeeId);
    }
}
