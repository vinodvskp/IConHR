using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class PerformaceSegmentQuestionModel
    {
        public int PerformanceQuestionID { get; set; }
        public Nullable<int> PerformanceSegmentID { get; set; }
        public string Question { get; set; }
        public string HelpText { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Answer { get; set; }
        public int? employeeRating { get; set; }
        public int? managerRating { get; set; }
    }
}
