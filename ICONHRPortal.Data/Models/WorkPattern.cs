using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class WorkPattern
    {
        public WorkPattern()
        {
            this.tblHolidays_AbsenceSettings = new List<tblHolidays_AbsenceSettings>();
        }

        public int WorkPatternId { get; set; }
        public string WorkPatternName { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public virtual ICollection<tblHolidays_AbsenceSettings> tblHolidays_AbsenceSettings { get; set; }
    }
}
