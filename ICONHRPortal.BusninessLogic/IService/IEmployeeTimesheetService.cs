using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IEmployeeTimesheetService
    {
        IEnumerable<EmployeeTimesheetModel> GetEmployeeTimesheets(long id);
        EmployeeTimesheetModel GetEmployeeTimesheet(long id);
        int Save(EmployeeTimesheetModel model);
        int Update(EmployeeTimesheetModel model);
        int Delete(long id);
        IEnumerable<EmployeeTimesheetModel> GetTimeSheetsByRptMng(long repMng);
    }
}
