using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Model
{
    public class PerformanceSegmentModel
    {
        public PerformanceSegmentModel()
        {
            tblPerformaceSegmentQuestions = new  List<PerformaceSegmentQuestionModel>();
        }
        public int PerformanceSegmentID { get; set; }
        public Nullable<int> PerformanceReviewID { get; set; }
        public string SegmentName { get; set; }
        public string SegmentDescription { get; set; }
        public string SegmentQuestion { get; set; }
        public IList<PerformaceSegmentQuestionModel> tblPerformaceSegmentQuestions { get; set; }
    }
}
