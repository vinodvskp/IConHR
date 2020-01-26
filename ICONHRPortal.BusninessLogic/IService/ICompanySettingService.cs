using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface ICompanySettingService
    {
        IEnumerable<CompanySettingModel> GetCompanySettings();
        CompanySettingModel GetCompanySettingById(int id);
        int SaveCompanySetting(CompanySettingModel model);
    }
}
