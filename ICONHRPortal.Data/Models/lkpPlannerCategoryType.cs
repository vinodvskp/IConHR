using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpPlannerCategoryType
    {
        public lkpPlannerCategoryType()
        {
            this.tblPlanners = new List<tblPlanner>();
        }

        public int PlannerCategoryID { get; set; }
        public string PlannerCategoryName { get; set; }
        public virtual ICollection<tblPlanner> tblPlanners { get; set; }
    }
}
