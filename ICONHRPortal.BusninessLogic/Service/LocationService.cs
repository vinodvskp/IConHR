using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository = null;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public IEnumerable<ChoiceOptionModel> GetLocations()
        {
            return _locationRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.LocationId,
                text = x.Location
            }).ToList();
        }

        public int SaveLocation(LocationModel model)
        {
            var location = Mapper.DynamicMap<lkpLocation>(model);
            _locationRepository.Add(location);
            return _locationRepository.SaveChanges();
        }
    }
}
