using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;

namespace ICONHRPortal.Data.Repository
{
   public class MgrReviewSegmentRepository : GenericRepository<tblMgrPerReviewSegment>, IMgrReviewSegmentRepository
    {
        public MgrReviewSegmentRepository(ICONHRContext context) : base(context)
        {

        }
    }
}
