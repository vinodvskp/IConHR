using ICONHRPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.BusninessLogic.IService
{
   public interface IEmailSettingService
    {
        IEnumerable<tblEmailSettingModel> GetEmailSettings();
        tblEmailSettingModel GetEmailSetting(long id);
        int Save(tblEmailSettingModel model);
        int Update(tblEmailSettingModel model);
        int Delete(long id);
    }
}
