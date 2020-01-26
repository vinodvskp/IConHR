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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository = null;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public IEnumerable<ChoiceOptionModel> GetCountries()
        {
            return _countryRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.CountryID,
                text = x.CountryName
            }).ToList();
        }
    }
}
