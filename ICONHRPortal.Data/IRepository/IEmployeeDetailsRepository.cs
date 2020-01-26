using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Data.IRepository
{
    public interface IEmployeeDetailsRepository : IGenericRepository<tblEmployeeDetail>
    {
        tblEmployeeDetail GetEmployeeDetail(long id);
        IEnumerable<EmployeeDetailsModel> GetEmployeeDetails(int? mgrId);
        int SaveBulkEmployees(List<tblEmployeeDetail> employees);
        EmployeeDetailsModel GetEmployee(long id);
    }
}
