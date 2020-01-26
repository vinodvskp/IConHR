using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class PerformanceScoreModel
    {
        public int ScoreID { get; set; }
        public int PerformanceReviewID { get; set; }
        public Nullable<int> RatingValue { get; set; }
        public string RatingDescription { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
