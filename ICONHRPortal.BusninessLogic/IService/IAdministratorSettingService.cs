using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IAdministratorSettingService
    {
        IEnumerable<AdministratorSettingModel> GetAdminSettingDetails(int id);
        IEnumerable<AdministratorSettingModel> GetAdminSettingDetailsByCompanyId(int id); // join more tables
        int SaveAdminSetting(AdministratorSettingModel model);
        int UpdateAdminSetting(AdministratorSettingModel model);
        bool CheckDuplicate(int id);
        IEnumerable<ChoiceOptionModel> GetAdminManagerNames();
    }
}
