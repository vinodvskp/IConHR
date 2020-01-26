using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblPerformanceSegment
    {
        public tblPerformanceSegment()
        {
            this.EmpMgrPerReviewSegments = new List<EmpMgrPerReviewSegment>();
            this.tblEmpPerReviewSegments = new List<tblEmpPerReviewSegment>();
            this.tblPerformaceSegmentQuestions = new List<tblPerformaceSegmentQuestion>();
        }

        public int PerformanceSegmentID { get; set; }
        public Nullable<int> PerformanceReviewID { get; set; }
        public string SegmentName { get; set; }
        public string SegmentDescription { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public virtual List<EmpMgrPerReviewSegment> EmpMgrPerReviewSegments { get; set; }
        public virtual List<tblEmpPerReviewSegment> tblEmpPerReviewSegments { get; set; }
        public virtual List<tblPerformaceSegmentQuestion> tblPerformaceSegmentQuestions { get; set; }
        public virtual tblPerformanceReviewSetting tblPerformanceReviewSetting { get; set; }
    }
}
