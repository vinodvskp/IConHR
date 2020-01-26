using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblEmployeeDetail
    {
        public tblEmployeeDetail()
        {
            this.tblAdministratorSettings = new List<tblAdministratorSetting>();
            this.tblCreditCardDetails = new List<tblCreditCardDetail>();
            this.tblDocuments = new List<tblDocument>();
            this.tblEmployeeJobDetails = new List<tblEmployeeJobDetail>();
            this.tblEmployeePerformances = new List<tblEmployeePerformance>();
            this.tblEmpPerReviewPerformances = new List<tblEmpPerReviewPerformance>();
            this.tblManagerPerformances = new List<tblManagerPerformance>();
            this.tblMgrPerReviewPerformances = new List<tblMgrPerReviewPerformance>();
        }

        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public Nullable<int> EmpRoleID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string CompanyUrl { get; set; }
        public string Location { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordToken { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string Address { get; set; }
        public string FileName { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string PostalCode { get; set; }
        public virtual lkpCountry lkpCountry { get; set; }
        public virtual lkpEmployeeRole lkpEmployeeRole { get; set; }
        public virtual ICollection<tblAdministratorSetting> tblAdministratorSettings { get; set; }
        public virtual tblCompanyDetail tblCompanyDetail { get; set; }
        public virtual ICollection<tblCreditCardDetail> tblCreditCardDetails { get; set; }
        public virtual ICollection<tblDocument> tblDocuments { get; set; }
        public virtual ICollection<tblEmployeeJobDetail> tblEmployeeJobDetails { get; set; }
        public virtual ICollection<tblEmployeePerformance> tblEmployeePerformances { get; set; }
        public virtual ICollection<tblEmpPerReviewPerformance> tblEmpPerReviewPerformances { get; set; }
        public virtual ICollection<tblManagerPerformance> tblManagerPerformances { get; set; }
        public virtual ICollection<tblMgrPerReviewPerformance> tblMgrPerReviewPerformances { get; set; }
    }
}
