using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class PlannerService : IPlannerService
    {
        private readonly IPlannerRepository _plannerRepository = null;
        private readonly IPlannerCategoryTypeRepository _plannerCategoryTypeRepository = null;

        public PlannerService(IPlannerRepository plannerRepository, IPlannerCategoryTypeRepository plannerCategoryTypeRepository)
        {
            _plannerRepository = plannerRepository;
            _plannerCategoryTypeRepository = plannerCategoryTypeRepository;
        }

        public int DeletePlanner(int id)
        {
            var planner = _plannerRepository.Find(x => x.PlannerID == id).FirstOrDefault();
            if (planner != null)
            {
                planner.Status = false;
                return _plannerRepository.SaveChanges();
            }

            return 0;
        }
        
        public int GetDepartmentId(int employeeId)
        {
            return _plannerRepository.GetDepartmentIdByEmployeeId(employeeId);
        }

        public long GetLocationByEmployeeId(int employeeId)
        {
            return _plannerRepository.GetLocationByEmployeeId(employeeId);
        }

        public IEnumerable<PlannerModel> GetPlanners()
        {
            return Mapper.DynamicMap<List<PlannerModel>>(_plannerRepository.GetAll().Where(x => x.Status != false).ToList());
        }

        public IEnumerable<ChoiceOptionModel> GetPlannerType()
        {
            return _plannerCategoryTypeRepository.GetAll().Select(x => new ChoiceOptionModel()
            {
                id = x.PlannerCategoryID,
                text = x.PlannerCategoryName
            }).ToList();
        }

        public int SavePlanner(PlannerModel model)
        {
            model.CreatedDate = DateTime.Now;
            var plannerEntity = Mapper.DynamicMap<tblPlanner>(model);
            _plannerRepository.Add(plannerEntity);
            return _plannerRepository.SaveChanges();
        }

        public int UpdatePlanner(PlannerModel model)
        {
            var planner = _plannerRepository.Find(x => x.PlannerID == model.PlannerID).FirstOrDefault();
            if (planner != null)
            {
                model.LastUpdatedDate = DateTime.Now;
                Mapper.CreateMap<PlannerModel, tblPlanner>()
                    .ForMember(dest => dest.PlannerID, opt => opt.Ignore()); // ignore primary key while update/delete
                tblPlanner plannerEntity = (tblPlanner)Mapper.Map(model, planner);

                return _plannerRepository.SaveChanges();
            }

            return 0;
        }

        public PlannerFilterModel GetFilterOptions()
        {
            return _plannerRepository.GetFilterOptions();
        }
    }
}
