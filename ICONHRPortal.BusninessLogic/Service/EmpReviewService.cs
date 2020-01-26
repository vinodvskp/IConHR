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
    public class EmpReviewService : IEmpReviewService
    {
        private readonly IEmpPerReviewRepository _empMgrPerReviewRepository = null;
        private readonly IPerformanceReviewSettingRepository _performanceReviewSettingRepository = null;

        public EmpReviewService(IEmpPerReviewRepository empMgrPerReviewRepository, IPerformanceReviewSettingRepository performanceReviewSettingRepository)
        {
            _empMgrPerReviewRepository = empMgrPerReviewRepository;
            _performanceReviewSettingRepository = performanceReviewSettingRepository;
        }

        public IEnumerable<EmpPerReviewPerformanceModel> EmpMgrPerReviewPerformanceById(int id)
        {
            return Mapper.DynamicMap<IEnumerable<EmpPerReviewPerformanceModel>>(_empMgrPerReviewRepository.GetEmpMgrPerReviewPerformanceById(id));
        }

        public PerformanceReviewSettingModel GetEmpMgrPerformanceDetailsByReviewId(int empid, int rptMgrId, int EmpMgrReviewId)
        {
            var settingData = Mapper.DynamicMap<PerformanceReviewSettingModel>(_performanceReviewSettingRepository.GetPerformanceSettingsById(EmpMgrReviewId));

           var data1 = _empMgrPerReviewRepository.GetSpEmpMgrPerformanceDetails(empid, rptMgrId, EmpMgrReviewId);

            foreach (var item in settingData.tblPerformanceSegments)
            {
                foreach (var question in item.tblPerformaceSegmentQuestions)
                {
                    var val = data1.Where(x => x.QuestionID == question.PerformanceQuestionID).FirstOrDefault();
                    if (val != null)
                    {
                        question.Answer = val.Answer;
                        question.employeeRating = val.RatingValue;
                    }
                        
                }
            };

            return settingData;
        }
        public SP_EmpScoreDetailsModel GetEmployeeScoreDetails(int empReviewId, int empid, int rptMgrId)
        {
            var scoreData = _empMgrPerReviewRepository.GetEmployeeScoreDetails(empReviewId, empid, rptMgrId);

            return scoreData;
        }
        public int Save(EmpPerReviewPerformanceModel model)
        {
            var employeePerReviewPerformance = Mapper.DynamicMap<tblEmpPerReviewPerformance>(model);
            _empMgrPerReviewRepository.Add(employeePerReviewPerformance);
            return _empMgrPerReviewRepository.SaveChanges();
        }

        public int Update(EmpPerReviewPerformanceModel model)
        {
            tblEmpPerReviewPerformance empReview = _empMgrPerReviewRepository
                .GetEmpPerReviewPerformancesById(model.EmpReviewID);

            for (int i = 0; i < model.tblEmpPerReviewSegments.Count ; i++)
            {
                for (int j = 0; j < model.tblEmpPerReviewSegments[i].tblEmpPerReviewRatings.Count; j++)
                {
                    empReview.tblEmpPerReviewSegments[i].tblEmpPerReviewRatings[j].ScoreID =
                        model.tblEmpPerReviewSegments[i].tblEmpPerReviewRatings[j].ScoreID;
                    empReview.tblEmpPerReviewSegments[i].tblEmpPerReviewRatings[j].Answer =
                        model.tblEmpPerReviewSegments[i].tblEmpPerReviewRatings[j].Answer;
                }
            }
            _empMgrPerReviewRepository.Update(empReview);
            return _empMgrPerReviewRepository.SaveChanges();
        }
    }
}
