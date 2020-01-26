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
    public class ManagerPerformanceService : IManagerPerformanceService
    {
        private readonly IMgrPerReviewRepository _mgrPerReviewRepository = null;
        private readonly IPerformanceReviewSettingRepository _performanceReviewSettingRepository = null;

        public ManagerPerformanceService(IMgrPerReviewRepository mgrPerReviewRepository, IPerformanceReviewSettingRepository performanceReviewSettingRepository)
        {
            _mgrPerReviewRepository = mgrPerReviewRepository;
            _performanceReviewSettingRepository = performanceReviewSettingRepository;
        }

        public PerformanceReviewSettingModel GetMgrPerformanceDetailsByReviewId(int empid, int rptMgrId, int EmpMgrReviewId)
        {
            var settingData = Mapper.DynamicMap<PerformanceReviewSettingModel>(_performanceReviewSettingRepository.GetPerformanceSettingsById(EmpMgrReviewId));

            var data1 = _mgrPerReviewRepository.GetSpMgrPerformanceDetails(empid, rptMgrId, EmpMgrReviewId);

            foreach (var item in settingData.tblPerformanceSegments)
            {
                foreach (var question in item.tblPerformaceSegmentQuestions)
                {
                    var val = data1.Where(x => x.QuestionID == question.PerformanceQuestionID).FirstOrDefault();
                    if (val != null)
                    {
                        question.Answer = val.Answer;
                        question.managerRating = val.RatingValue;
                    }

                }
            };

            return settingData;
        }

        public IEnumerable<MgrPerReviewPerformanceModel> MgrPerReviewPerformanceById(int id)
        {
            return Mapper.DynamicMap<IEnumerable<MgrPerReviewPerformanceModel>>(_mgrPerReviewRepository.GetMgrPerReviewPerformanceById(id));
        }

        public int Save(MgrPerReviewPerformanceModel model)
        {
            var managerPerReviewPerformance = Mapper.DynamicMap<tblMgrPerReviewPerformance>(model);
            _mgrPerReviewRepository.Add(managerPerReviewPerformance);
            return _mgrPerReviewRepository.SaveChanges();
        }

        public int Update(MgrPerReviewPerformanceModel model)
        {
            tblMgrPerReviewPerformance mgrReview = _mgrPerReviewRepository
                .GetEmpPerReviewPerformancesById(model.MgrReviewID);

            for (int i = 0; i < model.tblMgrPerReviewSegments.Count; i++)
            {
                for (int j = 0; j < model.tblMgrPerReviewSegments[i].tblMgrPerReviewRatings.Count; j++)
                {
                    mgrReview.tblMgrPerReviewSegments[i].tblMgrPerReviewRatings[j].ScoreID =
                        model.tblMgrPerReviewSegments[i].tblMgrPerReviewRatings[j].ScoreID;
                    mgrReview.tblMgrPerReviewSegments[i].tblMgrPerReviewRatings[j].Answer =
                        model.tblMgrPerReviewSegments[i].tblMgrPerReviewRatings[j].Answer;
                }
            }
            _mgrPerReviewRepository.Update(mgrReview);
            return _mgrPerReviewRepository.SaveChanges();
        }
    }
}
