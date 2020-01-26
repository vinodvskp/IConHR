using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ICONHRPortal.Model
{
    public class EmployeeNotificationModel
    {
        public int NotificationID { get; set; }
        public string ModifiedPropertyName { get; set; }
        public string OldPropertyName { get; set; }
        public string NewPropertyValue { get; set; }
        public bool NotificationShownStatus { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    }
}
