using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Data.IRepository
{
    public interface IAdministratorSettingRepository : IGenericRepository<tblAdministratorSetting>
    {
        IEnumerable<AdministratorSettingModel> GetAdminSettingDetailsByCompanyId(int id);
        IEnumerable<ChoiceOptionModel> GetAdminManagerNames();
    }
}
