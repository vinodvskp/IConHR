using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class MgrPerReviewSegmentModel
    {
        public MgrPerReviewSegmentModel()
        {
            this.tblMgrPerReviewRatings = new List<MgrPerReviewRatingModel>();
        }

        public int MgrReviewSegmentID { get; set; }
        public int PerformanceSegmentID { get; set; }
        public Nullable<int> MgrReviewID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public List<MgrPerReviewRatingModel> tblMgrPerReviewRatings { get; set; }
    }
}
