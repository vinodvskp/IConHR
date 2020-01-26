using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.IService
{
    public interface IDepartmentService
    {
        IEnumerable<ChoiceOptionModel> GetDepartments();
        int SaveDepartment(DepartmentModel model);
    }
}
