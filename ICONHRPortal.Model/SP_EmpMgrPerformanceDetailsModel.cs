using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
   public class SP_EmpMgrPerformanceDetailsModel
    {
        public int EMPID { get; set; }
        public string EmpName { get; set; }
        public int? RepMgrID { get; set; }
        public int PerformanceReviewID { get; set; }
        public int segmentid { get; set; }
        public string SegmentName { get; set; }
        public string SegmentDescription { get; set; }
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int ScoreID { get; set; }
        public int? RatingValue { get; set; }
    }
}
