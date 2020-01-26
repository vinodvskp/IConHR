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
    public class EmployeePerformanceService : IEmployeePerformanceService
    {
        private readonly IEmployeePerformanceRepository _employeePerformanceRepository = null;
        private readonly IPerformanceScoreRepository _performanceScoreRepository = null;

        public EmployeePerformanceService(IEmployeePerformanceRepository employeePerformanceRepository, IPerformanceScoreRepository performanceScoreRepository)
        {
            _employeePerformanceRepository = employeePerformanceRepository;
            _performanceScoreRepository = performanceScoreRepository;
        }

        public IEnumerable<ChoiceOptionModel> GetScoreRatingsChoice()
        {
            return _performanceScoreRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.ScoreID,
                text = x.RatingDescription
            });
        }

        public int Save(EmployeePerformanceModel model)
        {
            var employeePerformanceEntity = Mapper.DynamicMap<tblEmployeePerformance>(model);
            _employeePerformanceRepository.Add(employeePerformanceEntity);
            return _employeePerformanceRepository.SaveChanges();
        }
    }
}
