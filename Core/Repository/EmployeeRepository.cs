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
            this.Employee.Add(model);
            return true;
        }

        public bool Delete(int id, bool isSoft = false)
        {
            this.Employee.Remove(this.Employee.Find(mach => mach.Id == id));
            return true;
        }

        public List<Model> Read()
        {
            return this.Employee;
        }

        public Model Read(int id)
        {
            return this.Employee.Find(mach => mach.Id == id);
        }

        public bool Update(int id, Model model)
        {
            return true;
        }
    }
}
