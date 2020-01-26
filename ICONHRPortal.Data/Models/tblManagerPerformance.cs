using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblManagerPerformance
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
        public virtual tblEmployeeDetail tblEmployeeDetail { get; set; }
        public virtual tblPerformanceReviewSetting tblPerformanceReviewSetting { get; set; }
        public virtual tblPerformanceScore tblPerformanceScore { get; set; }
    }
}
