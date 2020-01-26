using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class PlannerFilterModel
    {
        public PlannerFilterModel()
        {
            EmployeeOptions = new System.Collections.Generic.List<ChoiceOptionModel>();
            LocationOptions = new System.Collections.Generic.List<ChoiceOptionModel>();
            DepartmentOptions = new System.Collections.Generic.List<ChoiceOptionModel>();
        }

        public List<ChoiceOptionModel> EmployeeOptions { get; set; }
        public List<ChoiceOptionModel> LocationOptions { get; set; }
        public List<ChoiceOptionModel> DepartmentOptions { get; set; }
    }
}
