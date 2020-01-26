using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblLogBook
    {
        public int LogBookID { get; set; }
        public int EmpId { get; set; }
        public string DocumentType { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public Nullable<System.DateTime> ApprisalReviewDate { get; set; }
        public Nullable<int> ApprisalReviewerID { get; set; }
        public string ApprisalReviewerName { get; set; }
        public string ApprisalNotes { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public string LicenceType { get; set; }
        public Nullable<System.DateTime> LicenceExpiryDate { get; set; }
        public string Comments { get; set; }
        public string Issue { get; set; }
        public string IssueStatus { get; set; }
        public Nullable<System.DateTime> IssueCreatedDate { get; set; }
        public Nullable<System.DateTime> IssueClosedDate { get; set; }
        public string IssueNotes { get; set; }
        public string TrainingType { get; set; }
        public string TrainingDescription { get; set; }
        public string PriorityType { get; set; }
        public string TrainingStatus { get; set; }
        public Nullable<System.DateTime> TrainingStartDate { get; set; }
        public Nullable<System.DateTime> TrainingEndDate { get; set; }
        public string TrainingNotes { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string DocName { get; set; }
        public string DocType { get; set; }
        public byte[] DocFile { get; set; }
    }
}
