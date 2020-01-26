using ICONHRPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Model;

namespace ICONHRPortal.Data.IRepository
{
    public interface IPerformanceSegmentRepository : IGenericRepository<tblPerformanceSegment>
    {
        IEnumerable<tblPerformanceSegment> GetPerformanceSegments();
        int BulkSegmentSave(IEnumerable<tblPerformanceSegment> models);
    }
}
