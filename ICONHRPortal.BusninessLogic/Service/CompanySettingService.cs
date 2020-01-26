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
    public class CompanySettingService : ICompanySettingService
    {
        private readonly ICompanySettingRepository _companySettingRepository = null;

        public CompanySettingService(ICompanySettingRepository companySettingRepository)
        {
            _companySettingRepository = companySettingRepository;
        }

        public CompanySettingModel GetCompanySettingById(int id)
        {
            return Mapper.DynamicMap<CompanySettingModel>(_companySettingRepository.Find(x=>x.CompanyID == id).FirstOrDefault());
        }

        public IEnumerable<CompanySettingModel> GetCompanySettings()
        {
            return Mapper.DynamicMap<List<CompanySettingModel>>(_companySettingRepository.GetAll().ToList());
        }

        public int SaveCompanySetting(CompanySettingModel model)
        {
            var companySettingEntity = _companySettingRepository.Find(x => x.CompanyID == model.CompanyID).FirstOrDefault();
            if (companySettingEntity == null)
            {
                var companySetting = Mapper.DynamicMap<tblCompanySetting>(model);
                _companySettingRepository.Add(companySetting);
                return _companySettingRepository.SaveChanges();
            }
            else
            {
               return Update(model);
            }
        }

        public int Update(CompanySettingModel model)
        {
            var companySetting = _companySettingRepository.Find(x => x.CompanyID == model.CompanyID).FirstOrDefault();
            if (companySetting != null)
            {
                model.UpdateDate = DateTime.Now;
                Mapper.CreateMap<CompanySettingModel, tblCompanySetting>()
                    .ForMember(dest => dest.CompanySettingID, opt => opt.Ignore()); // ignore primary key while update/delete
                tblCompanySetting tblCompanySetting = (tblCompanySetting)Mapper.Map(model, companySetting);

                return _companySettingRepository.SaveChanges();
            }

            return 0;
        }
    }
}
