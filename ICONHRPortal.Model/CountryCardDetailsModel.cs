using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class CountryCardDetailsModel
    {
        public IEnumerable<ChoiceOptionModel> Countries { get; set; }
        public IEnumerable<ChoiceOptionModel> CardExpireMonths { get; set; }
        public IEnumerable<ChoiceOptionModel> CardExpireYears { get; set; }
        public IEnumerable<ChoiceOptionModel> CardTypes { get; set; }
    }
}
