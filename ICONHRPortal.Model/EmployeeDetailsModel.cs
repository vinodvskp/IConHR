using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class EmployeeDetailsModel
    {
        public EmployeeDetailsModel()
        {
            tblEmployeeJobDetails = new List<tblEmployeeJobDetailsModel>();
        }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Password { get; set; }
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
        public string FileName { get; set; }
        public string Address { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string PostalCode { get; set; }
        public string ProfilePhotoBase64 { get; set; }
        public string EmpRole { get; set; }
        public string CountryName { get; set; }
        public string CompanyName { get; set; }
        public string JobRoleName { get; set; }
        public string LocationName { get; set; }
        public Nullable<int> ContractedHours { get; set; }
        public string DeptName { get; set; }
        public Nullable<System.DateTime> EmpStartDate { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public bool IsNewRecord { get; set; }
        public ICollection<CreditCardDetailModel> tblCreditCardDetails { get; set; }
        // public List<tblEmployeeJobDetailsModel> tblEmployeeJobDetailList { get; set; }
        public tblEmployeeJobDetailsModel objtblEmployeeJobDetails { get; set; }
        public List<tblEmployeeJobDetailsModel> tblEmployeeJobDetails { get; set; }
    }
}
