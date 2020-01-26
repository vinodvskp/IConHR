using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;

namespace ICONHRPortal.Data.Repository
{
   public class PlannerCategoryTypeRepository : GenericRepository<lkpPlannerCategoryType>, IPlannerCategoryTypeRepository
    {
        public PlannerCategoryTypeRepository(ICONHRContext context) : base(context)
        {

        }
    }
}
