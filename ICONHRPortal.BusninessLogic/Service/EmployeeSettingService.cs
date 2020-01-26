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


    public class EmployeeSettingService : IEmployeeSettingService
    {
        private readonly IEmployeeSettingRepository _employeeSettingRepository = null;

        public EmployeeSettingService(IEmployeeSettingRepository employeeSettingRepository)
        {
            _employeeSettingRepository = employeeSettingRepository;
        }

        public int Delete(long id)
        {
            throw new NotImplementedException();
        }


        public tblEmployeeSettingModel GetEmployeeSetting(long id)
        {
            return Mapper.DynamicMap<tblEmployeeSettingModel>(_employeeSettingRepository.Find(x => x.CompanyID == id).FirstOrDefault());
        }


        public IEnumerable<tblEmployeeSettingModel> GetEmployeeSettings()
        {
            return Mapper.DynamicMap<List<tblEmployeeSettingModel>>(_employeeSettingRepository.GetAll().ToList());
        }




        public int Save(tblEmployeeSettingModel model)
        {
           // var employeeSettings = Mapper.DynamicMap<tblEmployeeSetting>(model);
          //  _employeeSettingRepository.Add(employeeSettings);
           // return _employeeSettingRepository.SaveChanges();


            var employeeSetting = _employeeSettingRepository.Find(x => x.CompanyID == model.CompanyID).FirstOrDefault();
            if (employeeSetting == null)
            {
                var employeeSettings = Mapper.DynamicMap<tblEmployeeSetting>(model);
                _employeeSettingRepository.Add(employeeSettings);
            }
            else
            {
                model.EmployeeSettingsID = employeeSetting.EmployeeSettingsID;
                Update(model);
            }
            return _employeeSettingRepository.SaveChanges();
        }

        public int Update(tblEmployeeSettingModel model)
        {
            var employeeSettingsEntity = _employeeSettingRepository.Find(x => x.EmployeeSettingsID == model.EmployeeSettingsID).FirstOrDefault();
            if (employeeSettingsEntity != null)
            {
                Mapper.CreateMap<tblEmployeeSettingModel, tblEmployeeSetting>()
                    .ForMember(dest => dest.EmployeeSettingsID, opt => opt.Ignore()); // ignore primary key while update/delete
                tblEmployeeSetting employeeSettings = (tblEmployeeSetting)Mapper.Map(model, employeeSettingsEntity);

                return _employeeSettingRepository.SaveChanges();
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

