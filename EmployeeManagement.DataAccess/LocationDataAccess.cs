using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class LocationDataAccess:ILocationDataAccess
    {
        public void Build()
        {
            TinyMapper.Bind<Location, LocationModel>(config =>
            {
                config.Ignore(x => x.LocationEntityId);
                

            });
            TinyMapper.Bind<LocationModel, Location>();
        }
        

        public List<LocationModel> GetAll()
        {
            Build();
            List<LocationModel> locations = [];
            List<Location> locs = [];
            using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                context.Database.EnsureCreated();
                locs=context.Locations.ToList();

                foreach (Location loc in locs)
                {
                LocationModel location = TinyMapper.Map<LocationModel>(loc);
                    locations.Add(location);

                }
                context.SaveChanges();
            }

             return locations;

        }

        public bool Set(LocationModel location)
        {
            Build();
            using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                context.Database.EnsureCreated();
                Location loc = TinyMapper.Map<Location>(location);
                context.Locations.Add(loc);
                context.SaveChanges();

                

            }

               
            return true;
        } 
    }
}
