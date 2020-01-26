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
    public class HolidaysAbsenceSettingService : IHolidaysAbsenceSettingService
    {
        private readonly IHolidaysAbsenceSettingRepository _holidaysAbsenceSettingRepository = null;

        public HolidaysAbsenceSettingService(IHolidaysAbsenceSettingRepository holidaysAbsenceSettingRepository)
        {
            _holidaysAbsenceSettingRepository = holidaysAbsenceSettingRepository;
        }

        public int Delete(long id)
        {
            throw new NotImplementedException();
        }

        public tblHolidays_AbsenceSettingsModel GetHolidaysAbsenceSetting(long id)
        {
            return Mapper.DynamicMap<tblHolidays_AbsenceSettingsModel>(_holidaysAbsenceSettingRepository.Find(x=>x.CompanyID == id).FirstOrDefault());
        }

        public IEnumerable<tblHolidays_AbsenceSettingsModel> GetHolidaysAbsenceSettings()
        {
            return Mapper.DynamicMap<List<tblHolidays_AbsenceSettingsModel>>( _holidaysAbsenceSettingRepository.GetAll().ToList());
        }

        public int Save(tblHolidays_AbsenceSettingsModel model)
        {
            var holidaysAbsenceSettings = Mapper.DynamicMap<tblHolidays_AbsenceSettings>(model);
            _holidaysAbsenceSettingRepository.Add(holidaysAbsenceSettings);
            return _holidaysAbsenceSettingRepository.SaveChanges();
        }

        public int Update(tblHolidays_AbsenceSettingsModel model)
        {
            var holidaysAbsenceSettingsEntity = _holidaysAbsenceSettingRepository.Find(x => x.Holidays_AbsenceSettingID == model.Holidays_AbsenceSettingID).FirstOrDefault();
            if (holidaysAbsenceSettingsEntity != null)
            {
                Mapper.CreateMap<tblHolidays_AbsenceSettingsModel, tblHolidays_AbsenceSettings>()
                    .ForMember(dest => dest.Holidays_AbsenceSettingID, opt => opt.Ignore()); // ignore primary key while update/delete
                tblHolidays_AbsenceSettings holidaysAbsenceSettings = (tblHolidays_AbsenceSettings)Mapper.Map(model, holidaysAbsenceSettingsEntity);

                return _holidaysAbsenceSettingRepository.SaveChanges();
            }

            return 0;
        }
        //public IEnumerable<ChoiceOptionModel> GetCountries()
        //{
        //    return _countryRepository.GetAll().Select(x => new ChoiceOptionModel
        //    {
        //        id = x.CountryID,
        //        text = x.CountryName
        //    }).ToList();
        //}
    }
}
