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
    public class EmailSettingService : IEmailSettingService
    {
        private readonly IEmailSettingRepository _emailSettingRepository = null;

        public EmailSettingService(IEmailSettingRepository emailSettingRepository)
        {
            _emailSettingRepository = emailSettingRepository;
        }

        public int Delete(long id)
        {
            throw new NotImplementedException();
        }

        public tblEmailSettingModel GetEmailSetting(long id)
        {
            return Mapper.DynamicMap<tblEmailSettingModel>(_emailSettingRepository.Find(x => x.CompanyID == id).FirstOrDefault());
        }

        public IEnumerable<tblEmailSettingModel> GetEmailSettings()
        {
            return Mapper.DynamicMap<List<tblEmailSettingModel>>(_emailSettingRepository.GetAll().ToList());
        }

        public int Save(tblEmailSettingModel model)
        {
            var emailSetting = _emailSettingRepository.Find(x=>x.CompanyID == model.CompanyID).FirstOrDefault();
            if (emailSetting == null)
            {
                var emailSettings = Mapper.DynamicMap<tblEmailSettings>(model);
                _emailSettingRepository.Add(emailSettings);
            }
            else
            {
                model.EmailSettingsID = emailSetting.EmailSettingsID;
                Update(model);
            }
            return _emailSettingRepository.SaveChanges();
        }

        public int Update(tblEmailSettingModel model)
        {
            var emailSettingsEntity = _emailSettingRepository.Find(x => x.EmailSettingsID == model.EmailSettingsID).FirstOrDefault();
            if (emailSettingsEntity != null)
            {
                Mapper.CreateMap<tblEmailSettingModel, tblEmailSettings>()
                    .ForMember(dest => dest.EmailSettingsID, opt => opt.Ignore()); // ignore primary key while update/delete
                tblEmailSettings holidaysAbsenceSettings = (tblEmailSettings)Mapper.Map(model, emailSettingsEntity);

                return _emailSettingRepository.SaveChanges();
            }

            return 0;
        }
    }
}


