using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class ManagerPerformanceModel
    {
        public int ManagerPerformanceID { get; set; }
        public int EmpID { get; set; }
        public int RepMgrID { get; set; }
        public int PerformanceReviewID { get; set; }
        public int PerformanceSegmentID { get; set; }
        public int ScoreID { get; set; }
        public int PerformanceQuestionID { get; set; }
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
