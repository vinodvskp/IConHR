using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Model;

namespace ICONHRPortal.ApiService
{
    public class PlannerApiController : BaseApiController
    {
        private readonly IPlannerService _plannerService = null;

        public PlannerApiController(IPlannerService plannerService)
        {
            _plannerService = plannerService;
        }
        // GET api/<controller>
        public IEnumerable<PlannerModel> Get()
        {
            return _plannerService.GetPlanners();
        }

        // GET api/<controller>/5
        public IEnumerable<PlannerModel> Get(string fromScreen, int employeeId = 0)
        {
            if (fromScreen == "planner")
            {
                return _plannerService.GetPlanners();
            }
            if (employeeId == 0) // 0 means logged id expecting !=0 means selected employee id expecting
            {
                employeeId = int.Parse(base.UserIdentity);
            }
            return _plannerService.GetPlanners().Where(x=>x.EmpID == employeeId);
        }

        [HttpPost]
        [Route("api/plannerApi/searchFilters")]
        [ActionName("searchFilters")] //
        public IEnumerable<PlannerModel> searchFilters([FromBody]PlannerSearchModel model)
        {
            IEnumerable<PlannerModel> planners = _plannerService.GetPlanners();
            if (model.Locations.Length > 0)
            {
                planners = planners.Where(x=> model.Locations.Any(y=> y == x.LocationId));
            }
            if (model.Departments.Length > 0) // 0 means logged id expecting !=0 means selected employee id expecting
            {
                planners = planners.Where(x => model.Departments.Any(y => y == x.DepartmentId));
            }
            if (model.Employees.Length > 0) // 0 means logged id expecting !=0 means selected employee id expecting
            {
                planners = planners.Where(x => model.Employees.Any(y => y == x.EmpID));
            }

            return planners;
        }

        // POST api/<controller>
        public int Post([FromBody]PlannerModel model)
        {
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = UserName;
            model.Status = true;
            if (model.EmpID == null || model.EmpID == 0)
            {
                model.EmpID = int.Parse(base.UserIdentity);
                model.DepartmentId = DepartmentId;
                model.LocationId = LocationId;
            }
            else
            {
                // TODO when selected employee change then assign dept id based on selected empid
                model.DepartmentId = _plannerService.GetDepartmentId(model.EmpID.Value);
                model.LocationId = _plannerService.GetLocationByEmployeeId(model.EmpID.Value);
            }
            return _plannerService.SavePlanner(model);
        }

        // PUT api/<controller>/5
        public int Put([FromBody]PlannerModel model)
        {
            if (model.EmpID == null || model.EmpID == 0)
            {
                model.EmpID = int.Parse(base.UserIdentity);
                model.DepartmentId = DepartmentId;
                model.LocationId = LocationId;
            }
            else
            {
                // TODO when selected employee change then assign dept id based on selected empid
                model.DepartmentId = _plannerService.GetDepartmentId(model.EmpID.Value);
                model.LocationId = _plannerService.GetLocationByEmployeeId(model.EmpID.Value);
            }
            model.Status = true;
            model.LastUpdatedBy = UserName;
          return  _plannerService.UpdatePlanner(model);
        }

        // DELETE api/<controller>/5
        public int Delete(int id)
        {
            return _plannerService.DeletePlanner(id);
        }

        [HttpGet]
        [Route("api/plannerApi/PlannerTypes")]
        [ActionName("PlannerTypes")] //
        public IEnumerable<ChoiceOptionModel> PlannerTypes()
        {
            return _plannerService.GetPlannerType();
        }

        [HttpGet]
        [Route("api/plannerApi/PlannerFilter")]
        [ActionName("PlannerFilter")] //
        public PlannerFilterModel PlannerFilter()
        {
            return _plannerService.GetFilterOptions();
        }
    }

    public class PlannerSearchModel
    {
        //int[] locations,int[] departments, int[] employees
        public int[] Locations { get; set; }
        public int[] Departments { get; set; }
        public int[] Employees { get; set; }
    }
}