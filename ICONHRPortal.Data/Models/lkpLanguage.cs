using System;
using System.Collections.Generic;

namespace ICONHRPortal.Data.Models
{
    public partial class lkpLanguage
    {
        public lkpLanguage()
        {
            this.tblLocalizationSettings = new List<tblLocalizationSetting>();
        }

        public int LanguageID { get; set; }
        public string LanguageDesc { get; set; }
        public virtual ICollection<tblLocalizationSetting> tblLocalizationSettings { get; set; }
    }
}
