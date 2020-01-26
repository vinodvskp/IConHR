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
    public class AdministratorSettingService : IAdministratorSettingService
    {
        private readonly IAdministratorSettingRepository _administratorSettingRepository = null;
        private readonly IEmployeeDetailsRepository _employeeDetailsRepository = null;

        public AdministratorSettingService(IAdministratorSettingRepository administratorSettingRepository, IEmployeeDetailsRepository employeeDetailsRepository)
        {
            _administratorSettingRepository = administratorSettingRepository;
            _employeeDetailsRepository = employeeDetailsRepository;
        }

        public bool CheckDuplicate(int id)
        {
            var adminSetting = _administratorSettingRepository.Find(x => x.AdministratorSettingID == id).FirstOrDefault();
            if (adminSetting != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<AdministratorSettingModel> GetAdminSettingDetails(int id)
        {
            return Mapper.DynamicMap<List<AdministratorSettingModel>>(_administratorSettingRepository.Find(x => x.CompanyID == id).ToList());
        }

        public IEnumerable<AdministratorSettingModel> GetAdminSettingDetailsByCompanyId(int id)
        {
            return Mapper.DynamicMap<List<AdministratorSettingModel>>(_administratorSettingRepository.GetAdminSettingDetailsByCompanyId(id));
        }

        public int SaveAdminSetting(AdministratorSettingModel model)
        {
            if (model.AssignedEmployeeID.HasValue)
            {
                if (CheckDuplicate(model.AssignedEmployeeID.Value))
                {
                    throw new Exception("Already employee assigned as administrator");
                }

            }

            model.CreatedDate = DateTime.Now;
            var administratorSetting = Mapper.DynamicMap<tblAdministratorSetting>(model);
            _administratorSettingRepository.Add(administratorSetting);
            _administratorSettingRepository.SaveChanges();

            // Update role id in employee detail table
            var employeeDetail = _employeeDetailsRepository.Get(model.AssignedEmployeeID.Value);
            employeeDetail.EmpRoleID = 1;
            employeeDetail.LastUpdatedDate = DateTime.Now;
            employeeDetail.LastUpdatedBy = model.LastUpdatedBy;
            return _employeeDetailsRepository.SaveChanges();
        }

        public int UpdateAdminSetting(AdministratorSettingModel model)
        {
            var administratorSetting = _administratorSettingRepository.Find(x => x.CompanyID == model.CompanyID).FirstOrDefault();
            if (administratorSetting != null)
            {
                Mapper.CreateMap<AdministratorSettingModel, tblAdministratorSetting>()
                    .ForMember(dest => dest.AdministratorSettingID, opt => opt.Ignore());
                tblAdministratorSetting adminsetting = (tblAdministratorSetting)Mapper.Map(model, administratorSetting);

                return _administratorSettingRepository.SaveChanges();
            }

            return 0;
        }

        public IEnumerable<ChoiceOptionModel> GetAdminManagerNames()
        {
            return _administratorSettingRepository.GetAdminManagerNames();
        }
    }
}
