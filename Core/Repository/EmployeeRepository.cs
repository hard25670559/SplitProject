using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Repository
{
    public class EmployeeRepository : IRepository
    {

        public List<Model> Employee = new List<Model>();

        public EmployeeRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                this.Employee.Add(new Employee
                {
                    Id = i,
                    Account = "account",
                    Create = DateTime.Now,
                    Delete = false,
                    Name = "name",
                    Password = "password",
                    Update = DateTime.Now
                });
            }
        }

        public bool Create(Model model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, bool isSoft = false)
        {
            throw new NotImplementedException();
        }

        public List<Model> Read()
        {
            return this.Employee;
        }

        public Model Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Model model)
        {
            throw new NotImplementedException();
        }
    }
}
