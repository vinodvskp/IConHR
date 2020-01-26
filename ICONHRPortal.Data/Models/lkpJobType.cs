using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpJobType
    {
        public lkpJobType()
        {
            this.tblEmployeeJobDetails = new List<tblEmployeeJobDetail>();
        }

        public int JobTypeID { get; set; }
        public string JobType { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual ICollection<tblEmployeeJobDetail> tblEmployeeJobDetails { get; set; }
    }
}
