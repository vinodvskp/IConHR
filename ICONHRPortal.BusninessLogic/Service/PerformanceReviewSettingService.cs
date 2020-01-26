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
    public class PerformanceReviewSettingService : IPerformanceReviewSettingService
    {
        private readonly IPerformanceReviewSettingRepository _performanceReviewSettingRepository = null;
        private readonly IJobRoleRepository _jobRoleRepository = null;
        private readonly IEmploymentTypeRepository _employmentTypeRepository = null;
        private readonly IPerformanceSegmentRepository _performanceSegmentRepository = null;
        private readonly IPerformancesegmentQuestionRepository _performancesegmentQuestionRepository = null;

        public PerformanceReviewSettingService(IPerformanceReviewSettingRepository performanceReviewSettingRepository,
            IJobRoleRepository jobRoleRepository, IEmploymentTypeRepository employmentTypeRepository,
            IPerformancesegmentQuestionRepository performancesegmentQuestionRepository,
            IPerformanceSegmentRepository performanceSegmentRepository)
        {
            _performanceReviewSettingRepository = performanceReviewSettingRepository;
            _jobRoleRepository = jobRoleRepository;
            _employmentTypeRepository = employmentTypeRepository;
            _performanceSegmentRepository = performanceSegmentRepository;
            _performancesegmentQuestionRepository = performancesegmentQuestionRepository;
        }

        public int DeletePerformanceReviewSetting(int id)
        {
            var performanceReviewSetting = _performanceReviewSettingRepository.Find(x => x.PerformanceReviewID == id).FirstOrDefault();
            if (performanceReviewSetting != null)
            {
                performanceReviewSetting.Status = false;
                _performanceReviewSettingRepository.SaveChanges();
            }

            return 0;
        }

        public PerformanceReviewSettingModel GetPerformanceReviewSetting(int id)
        {
            return Mapper.DynamicMap<PerformanceReviewSettingModel>(_performanceReviewSettingRepository.GetPerformanceSettingsById(id));
        }

        public List<PerformanceReviewSettingModel> GetPerformanceReviewSettings()
        {
            return Mapper.DynamicMap<List<PerformanceReviewSettingModel>>(_performanceReviewSettingRepository.GetPerformanceSettings().ToList());
        }

        public int SavePerformanceReviewSetting(PerformanceReviewSettingModel model)
        {
            var performanceReviewSetting = Mapper.DynamicMap<tblPerformanceReviewSetting>(model);
            _performanceReviewSettingRepository.Add(performanceReviewSetting);
            return _performanceReviewSettingRepository.SaveChanges();
        }

        public int UpdatePerformanceReviewSetting(PerformanceReviewSettingModel model)
        {
            tblPerformanceReviewSetting performanceReviewSettingEntity = _performanceReviewSettingRepository
                .GetPerformanceSettingsById(model.PerformanceReviewID);
            if (performanceReviewSettingEntity != null)
            {
                //Mapper.CreateMap<PerformanceReviewSettingModel, tblPerformanceReviewSetting>()
                //    .ForMember(dest => dest.PerformanceReviewID, opt => opt.Ignore()); // ignore primary key while update/delete
                //tblPerformanceReviewSetting obj = (tblPerformanceReviewSetting)Mapper.Map(model, performanceReviewSettingEntity);

                performanceReviewSettingEntity.ReviewTitle = model.ReviewTitle;
                performanceReviewSettingEntity.ReviewCompletionDate = model.ReviewCompletionDate;
                performanceReviewSettingEntity.CompanyID = model.CompanyID;
                performanceReviewSettingEntity.LocationID = model.LocationID;
                performanceReviewSettingEntity.DepartmentID = model.DepartmentID;
                performanceReviewSettingEntity.JobRoleID = model.JobRoleID;
                performanceReviewSettingEntity.EmploymentTypeID = model.EmploymentTypeID;
                performanceReviewSettingEntity.LengthOfService = model.LengthOfService;
                performanceReviewSettingEntity.CreatedBy = model.CreatedBy;
                performanceReviewSettingEntity.CreatedDate = model.CreatedDate;
                performanceReviewSettingEntity.LastUpdatedBy = model.LastUpdatedBy;
                performanceReviewSettingEntity.LastUpdatedDate = model.LastUpdatedDate;

                List<PerformanceSegmentModel> segments = new List<PerformanceSegmentModel>();
                List<PerformaceSegmentQuestionModel> Questions = new List<PerformaceSegmentQuestionModel>();
                for (int i = 0; i < model.tblPerformanceSegments.Count; i++)
                {
                    if (model.tblPerformanceSegments[i].PerformanceSegmentID == 0)
                    {
                        model.tblPerformanceSegments[i].PerformanceReviewID = model.PerformanceReviewID;
                        //PerformanceSegmentModel segm = new PerformanceSegmentModel();
                        //segm.PerformanceReviewID = model.tblPerformanceSegments[i].PerformanceReviewID;
                        //segm.SegmentDescription = model.tblPerformanceSegments[i].SegmentDescription;
                        ////segm.CreatedDate = DateTime.Now;
                        ////segm.CreatedBy = model.CreatedBy;
                        //segm.SegmentName = model.tblPerformanceSegments[i].SegmentName;
                        model.tblPerformanceSegments[i].tblPerformaceSegmentQuestions = new List<PerformaceSegmentQuestionModel>();
                        segments.Add(model.tblPerformanceSegments[i]);
                    }
                    else
                    {
                        performanceReviewSettingEntity.tblPerformanceSegments[i].SegmentName = model.tblPerformanceSegments[i].SegmentName;
                        performanceReviewSettingEntity.tblPerformanceSegments[i].SegmentDescription = model.tblPerformanceSegments[i].SegmentDescription;
                        // question updates
                        for (int j = 0; j < model.tblPerformanceSegments[i].tblPerformaceSegmentQuestions.Count; j++)
                        {
                            if (model.tblPerformanceSegments[i].tblPerformaceSegmentQuestions[j].PerformanceQuestionID == 0)
                            {
                                // while updating adding aditional record for question
                                model.tblPerformanceSegments[i].tblPerformaceSegmentQuestions[j].PerformanceSegmentID =
                                    model.tblPerformanceSegments[i].PerformanceSegmentID;
                                Questions.Add(model.tblPerformanceSegments[i].tblPerformaceSegmentQuestions[j]);
                            }
                            else
                            {
                                performanceReviewSettingEntity.tblPerformanceSegments[i]
                                        .tblPerformaceSegmentQuestions[j].Question =
                                    model.tblPerformanceSegments[i].tblPerformaceSegmentQuestions[j].Question;
                                performanceReviewSettingEntity.tblPerformanceSegments[i]
                                        .tblPerformaceSegmentQuestions[j].HelpText =
                                    model.tblPerformanceSegments[i].tblPerformaceSegmentQuestions[j].HelpText;
                            }
                        }
                    }
                }

                _performanceReviewSettingRepository.Update(performanceReviewSettingEntity);
                _performanceReviewSettingRepository.SaveChanges();
                if (segments.Count > 0)
                {
                    foreach (var seg in segments)
                    {
                        //var entityPerformanceSegment = Mapper.DynamicMap<tblPerformanceSegment>(seg);
                        ////var entityPerformanceSegment = new tblPerformanceSegment {SegmentDescription = "sdfsdfsd", SegmentName = "sfsdfsdfsf"};
                        //entityPerformanceSegment.Status = true;

                        //entityPerformanceSegment.CreatedDate = DateTime.Now;
                        ////entityPerformanceSegment.tblPerformanceReviewSetting= new tblPerformanceReviewSetting();
                        //_performanceSegmentRepository.Add(entityPerformanceSegment);
                        //_performanceSegmentRepository.SaveChanges();

                    }

                    var entityPerformanceSegments = Mapper.DynamicMap<List<tblPerformanceSegment>>(segments);
                    _performanceSegmentRepository.BulkSegmentSave(entityPerformanceSegments);

                }

                if (segments.Count == 0 && Questions.Count > 0)
                {
                    // TODO insert question into question table
                    foreach (var question in Questions)
                    {
                        question.CreatedDate = DateTime.Now;
                        question.Status = true;
                        var entityPerformanceQuestion = Mapper.DynamicMap<tblPerformaceSegmentQuestion>(question);
                        //entityPerformanceQuestion.tblPerformanceSegment = new tblPerformanceSegment();
                        _performancesegmentQuestionRepository.Add(entityPerformanceQuestion);
                        _performancesegmentQuestionRepository.SaveChanges();
                    }
                }

                return 1;
            }

            return 0;
        }

        public IEnumerable<ChoiceOptionModel> GetJobRoleNames()
        {
            return _jobRoleRepository.GetAll().Select(x => new ChoiceOptionModel()
            {
                id = x.JobRoleID,
                text = x.JobRole
            }).ToList();
        }

        public IEnumerable<ChoiceOptionModel> GetEmploymentTypes()
        {
            return _employmentTypeRepository.GetAll().Select(x => new ChoiceOptionModel()
            {
                id = x.EmploymentTypeID,
                text = x.EmploymentTypeDesc
            }).ToList();
        }

        public IEnumerable<ChoiceOptionModel> GetReviewNames()
        {
            return _performanceReviewSettingRepository.GetAll().Select(x => new ChoiceOptionModel()
            {
                id = x.PerformanceReviewID,
                text = x.ReviewTitle
            }).ToList();
        }
    }
}
