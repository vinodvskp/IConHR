using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Model;
using AutoMapper;
using System.Data.SqlClient;
using System.Data;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class CompanyDetailService : ICompanyDetailService
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository = null;

        public CompanyDetailService(ICompanyDetailsRepository companyDetailsRepository)
        {
            _companyDetailsRepository = companyDetailsRepository;
        }

        public IList<CompanyDetailModel> GetCompanyDetails()
        {
            return Mapper.DynamicMap<List<CompanyDetailModel>>(_companyDetailsRepository.GetAll()).ToList();
        }

    }
}
