using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.Data.Repository
{
   public class PerformanceSegmentRepository : GenericRepository<tblPerformanceSegment>, IPerformanceSegmentRepository
    {
        public PerformanceSegmentRepository(ICONHRContext context) : base(context)
        {

        }

        public IEnumerable<tblPerformanceSegment> GetPerformanceSegments()
        {
            return _IconhrContext.PerformanceSegments.Include("tblPerformaceSegmentQuestions").ToList();
            //  .Include(x => x.tblPerformanceSegments.Select(y => y.tblPerformaceSegmentQuestions))
            //.Include("tblPerformanceScores")
        }

        int IPerformanceSegmentRepository.BulkSegmentSave(IEnumerable<tblPerformanceSegment> models)
        {
            foreach (var item in models)
            {
                item.Status = true;
                item.CreatedDate = DateTime.Now;
                _IconhrContext.PerformanceSegments.Add(item);
            }

            return SaveChanges();
        }

        IEnumerable<tblPerformanceSegment> IPerformanceSegmentRepository.GetPerformanceSegments()
        {
            throw new NotImplementedException();
        }
    }
}
