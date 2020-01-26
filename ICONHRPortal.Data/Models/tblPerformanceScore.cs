using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblPerformanceScore
    {
        public tblPerformanceScore()
        {
            this.tblEmployeePerformances = new List<tblEmployeePerformance>();
            this.tblManagerPerformances = new List<tblManagerPerformance>();
        }

        public int ScoreID { get; set; }
        public int PerformanceReviewID { get; set; }
        public Nullable<int> RatingValue { get; set; }
        public string RatingDescription { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual ICollection<tblEmployeePerformance> tblEmployeePerformances { get; set; }
        public virtual ICollection<tblManagerPerformance> tblManagerPerformances { get; set; }
        public virtual tblPerformanceReviewSetting tblPerformanceReviewSetting { get; set; }
    }
}
