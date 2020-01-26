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
    public class WorkPatternService : IWorkPatternService
    {
        private readonly IWorkPatternRepository _workPatternRepository = null;

        public WorkPatternService(IWorkPatternRepository workPatternRepository)
        {
            _workPatternRepository = workPatternRepository;
        }
        public IEnumerable<ChoiceOptionModel> GetWorkPatternsOptions()
        {
            return _workPatternRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.WorkPatternId,
                text = x.WorkPatternName
            }).ToList();
        }

        public int SaveWorkPattern(WorkPatternModel model)
        {
            var workPattern = Mapper.DynamicMap<WorkPattern>(model);
            _workPatternRepository.Add(workPattern);
            return _workPatternRepository.SaveChanges();
        }
    }
}
