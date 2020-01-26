using ICONHRPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IEmployeeSettingService
    {
        IEnumerable<tblEmployeeSettingModel> GetEmployeeSettings();
        tblEmployeeSettingModel GetEmployeeSetting(long id);
        int Save(tblEmployeeSettingModel model);
        int Update(tblEmployeeSettingModel model);
        int Delete(long id);
    }
}
