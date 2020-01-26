using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;

namespace ICONHRPortal.Data.Repository
{
   public class HolidaysAbsenceSettingRepository : GenericRepository<tblHolidays_AbsenceSettings>, IHolidaysAbsenceSettingRepository
    {
        public HolidaysAbsenceSettingRepository(ICONHRContext context) : base(context)
        {

        }
    }
}
