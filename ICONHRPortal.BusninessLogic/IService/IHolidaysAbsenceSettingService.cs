using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IHolidaysAbsenceSettingService
    {
        IEnumerable<tblHolidays_AbsenceSettingsModel> GetHolidaysAbsenceSettings();
        tblHolidays_AbsenceSettingsModel GetHolidaysAbsenceSetting(long id);
        int Save(tblHolidays_AbsenceSettingsModel model);
        int Update(tblHolidays_AbsenceSettingsModel model);
        int Delete(long id);
    }
}
