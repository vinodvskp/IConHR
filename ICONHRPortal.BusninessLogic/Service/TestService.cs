using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class TestServce 
    {
        private readonly ICompanySettingRepository _companySettingRepository = null;

        public TestServce(ICompanySettingRepository companySettingRepository)
        {
            _companySettingRepository = companySettingRepository;
        }
       
    }
}
