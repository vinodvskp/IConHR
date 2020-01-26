using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpEmploymentType
    {
        public lkpEmploymentType()
        {
            this.PerformanceReviewSettings = new List<PerformanceReviewSetting>();
            this.tblPerformanceReviewSettings = new List<tblPerformanceReviewSetting>();
        }

        public int EmploymentTypeID { get; set; }
        public string EmploymentTypeDesc { get; set; }
        public virtual ICollection<PerformanceReviewSetting> PerformanceReviewSettings { get; set; }
        public virtual ICollection<tblPerformanceReviewSetting> tblPerformanceReviewSettings { get; set; }
    }
}
