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
        
        public bool Add(LocationModel location)
        {
            Location loc = TinyMapper.Map<Location>(location);
            return locationDataAccess.Set(loc); ;
        }

        public List<LocationModel> ViewAll()
        {
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
