
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Model;
using AutoMapper;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class PerformanceSegmentService : IPerformanceSegmentService
    {
        private readonly IPerformanceSegmentRepository _performanceSegmentRepository = null;
        private readonly IPerformanceScoreRepository _performanceScoreRepository = null;

        public PerformanceSegmentService(IPerformanceSegmentRepository performanceSegmentRepository, IPerformanceScoreRepository performanceScoreRepository)
        {
            _performanceSegmentRepository = performanceSegmentRepository;
            _performanceScoreRepository = performanceScoreRepository;
        }

        public IEnumerable<PerformanceScoreModel> GetPerformanceScoreRatings()
        {
            return Mapper.DynamicMap<List<PerformanceScoreModel>>(_performanceSegmentRepository.GetAll().ToList());
        }

        public IEnumerable<PerformanceSegmentModel> GetPerformancesegments()
        {
            return Mapper.DynamicMap<List<PerformanceSegmentModel>>(_performanceSegmentRepository.GetPerformanceSegments().ToList());
        }
    }
}
