using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;

namespace EmployeeManagement.DataAccess
{
    public class RoleDataAccess:IRoleDataAccess
    {
        public void Build() {

            TinyMapper.Bind<Role, RoleModel>(config =>
            {
                config.Ignore(x => x.RoleEntityId);


            });
            TinyMapper.Bind<RoleModel, Role>();
        }


        public List<RoleModel> GetAll()
        {
            Build();
            List<RoleModel> roles = new List<RoleModel>(); // Initialize the list
            List<Role>roleDataList= new List<Role>();
            using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                context.Database.EnsureCreated();
                roleDataList=context.Roles.ToList();

                foreach(Role role in roleDataList)
                {
                
                    roles.Add(TinyMapper.Map<RoleModel>(role));
                }
                context.SaveChanges();

            }
            return roles;
        }


        public bool Set(RoleModel role)
        {
            Build();
            using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                context.Database.EnsureCreated();
                Role roleData=TinyMapper.Map<Role>(role);
                context.Roles.Add(roleData);
                context.SaveChanges();

            }
                return true;
        }

    }
}
