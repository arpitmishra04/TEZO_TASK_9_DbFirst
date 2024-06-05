using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public class LocationService:ILocationService
    {
        private ILocationDataAccess locationDataAccess;
        public LocationService(ILocationDataAccess _locationDataAccess) {
            this.locationDataAccess = _locationDataAccess;
        }

        public void Build()
        {
            TinyMapper.Bind<Location, LocationModel>(config =>
            {
                config.Ignore(x => x.LocationEntityId);


            });
            TinyMapper.Bind<LocationModel, Location>();
        }
        public bool Add(LocationModel location)
        {
            Build();
            Location loc = TinyMapper.Map<Location>(location);
            return locationDataAccess.Set(loc); 
        }

        public List<LocationModel> ViewAll()
        {
            Build();
            List<LocationModel> locations = [];
            List<Location> locs = locationDataAccess.GetAll();

            foreach (Location loc in locs)
            {
                LocationModel location = TinyMapper.Map<LocationModel>(loc);
                locations.Add(location);

            }
            return locations;
        }
    }
}
