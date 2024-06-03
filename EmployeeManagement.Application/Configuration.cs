using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Configuration
    {
        public void Build() {
            try
            {
                var configuration = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
             .Build();
                string ConString = configuration.GetConnectionString("DefaultConnectionString")!;
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

        }
        }
}
