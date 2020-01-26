using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class tblLocalizationSetting
    {
        public int LocalizationSettingID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> CompanyDefaultLanguageID { get; set; }
        public Nullable<long> LocationID { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public virtual lkpLanguage lkpLanguage { get; set; }
        public virtual lkpLocation lkpLocation { get; set; }
        public virtual tblCompanyDetail tblCompanyDetail { get; set; }
    }
}
