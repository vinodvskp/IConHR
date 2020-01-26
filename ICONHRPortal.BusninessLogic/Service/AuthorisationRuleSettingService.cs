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
    public class AuthorisationRuleSettingService: IAuthorisationRuleSettingService
    {
        private readonly IAuthorisationRuleSettingRepository _authorisationRuleRepository = null;


        public AuthorisationRuleSettingService(IAuthorisationRuleSettingRepository authorisationRuleRepository)
        {
            _authorisationRuleRepository = authorisationRuleRepository;
;
        }
        public IEnumerable<tblAuthorisationRuleSettingModel> GetAuthorisationRuleDetails()
        {
            return Mapper.DynamicMap<List<tblAuthorisationRuleSettingModel>>(_authorisationRuleRepository.GetAll().ToList());
        }

        public int Save(tblAuthorisationRuleSettingModel model)
        {
            var ruleData = Mapper.DynamicMap<tblAuthorisationRuleSetting>(model);
            _authorisationRuleRepository.Add(ruleData);
            return _authorisationRuleRepository.SaveChanges();
        }

        public int Update(tblAuthorisationRuleSettingModel model)
        {
            var ruleData = _authorisationRuleRepository.Find(x => x.AuthorisationRuleSettingsID == model.AuthorisationRuleSettingsID).FirstOrDefault();
            if (ruleData != null)
            {
                Mapper.CreateMap<tblAuthorisationRuleSettingModel, tblAuthorisationRuleSetting>()
                    .ForMember(dest => dest.AuthorisationRuleSettingsID,
                        opt => opt.Ignore()); // ignore primary key while update/delete
                tblAuthorisationRuleSetting employeeTimesheetEntity = Mapper.Map(model, ruleData);

                return _authorisationRuleRepository.SaveChanges();
            }

            return 0;
        }
    }
}
