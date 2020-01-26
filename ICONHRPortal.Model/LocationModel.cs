using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class LocationModel
    {
        public long LocationId { get; set; }
        public string Location { get; set; }
        public Nullable<int> CompanyId { get; set; }
    }
}
