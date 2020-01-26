using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IAuthorisationRuleSettingService
    {
        IEnumerable<tblAuthorisationRuleSettingModel> GetAuthorisationRuleDetails();
        int Save(tblAuthorisationRuleSettingModel model);
        int Update(tblAuthorisationRuleSettingModel model);
    }
}
