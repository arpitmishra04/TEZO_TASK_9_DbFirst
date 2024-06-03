using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using EmployeeManagement.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Operations
{
    public class LocationOperation:ILocationOperation
    {
        private ILocationService locationService;
        public LocationOperation(ILocationService _locationservice) { 
            this.locationService = _locationservice;
        }
        private  readonly Random random = new Random();
        public int Add(string locationName)
        {
          
            int locationId = GenerateId();
            LocationModel location = new LocationModel
            {
                LocationId = locationId,
                LocationName = locationName,
            };
            
            locationService.Add(location);
            return locationId;
        }

        private int GenerateId()
        {
           
            List<LocationModel> locationList =locationService.ViewAll();
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            int id = 0;

            if (locationList.Count() == 0)
            {
                id = random.Next(1, 1000);
            }

            else
            {
                id = locationList[locationList.Count() - 1].LocationId + random.Next(1, 900);
            }

            return id;
        }
    }
}
