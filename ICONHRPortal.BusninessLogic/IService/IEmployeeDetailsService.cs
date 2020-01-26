using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Model;


namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IEmployeeDetailsService
    {
        IList<EmployeeDetailsModel> GetEmployeeDetailsModels(int? mgrId);
        EmployeeDetailsModel GetEmployeeDetailsById(int id);
        bool HasEmailIdExists(string email);
        bool HasCompanyUrlxists(string url);

        int SaveEmployee(EmployeeDetailsModel model);
        int SaveBulkEmployees(List<EmployeeDetailsModel> employees);
        int UpdateEmployee(EmployeeDetailsModel model);
        IEnumerable<ChoiceOptionModel> GetEmplyeeNamesByCompanyId(int id);
        IList<EmployeeDetailsModel> GetAdminDetails();
        IList<EmployeeNotificationModel> GetNotificaitons();
        int updateNotificaitonStatus(EmployeeNotificationModel model);
        EmployeeDetailsModel GetEmployee(int id);
    }
}
