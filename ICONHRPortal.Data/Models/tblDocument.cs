using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblDocument
    {
        public int DocumentID { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> EmpID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DocumentName { get; set; }
        public Nullable<int> DocumentCategoryTypeID { get; set; }
        public Nullable<System.DateTime> DocumentAddedDate { get; set; }
        public Nullable<bool> EmployeeAcess { get; set; }
        public Nullable<bool> MangerAcess { get; set; }
        public Nullable<bool> IsCompanyAccessOnly { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public virtual tblEmployeeDetail tblEmployeeDetail { get; set; }
    }
}
