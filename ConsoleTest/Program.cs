using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Repository;
using static Core.Setting;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            IRepository repository = RepositoryFactory.Repository(Alias.Employee);

            Console.WriteLine("======================Read===========================");

            List<Model> user = repository.Read();

            foreach (Employee item in user)
            {
                Console.WriteLine("Id: " + item.Id + " Account: " + item.Account + " Password: " + item.Password + " Name: " + item.Name);
            }

            Console.WriteLine("======================Create===========================");

            repository.Create(new Employee
            {
                Account = "test",
                Create = DateTime.Now,
                Delete = false,
                Id = 394809834,
                Name = "test",
                Password = "test",
                Update = DateTime.Now
            });

            user = repository.Read();

            foreach (Employee item in user)
            {
                Console.WriteLine("Id: " + item.Id + " Account: " + item.Account + " Password: " + item.Password + " Name: " + item.Name);
            }

            Console.WriteLine("======================Find===========================");

            Employee employee = repository.Read(394809834) as Employee;

            Console.WriteLine("Id: " + employee.Id + " Account: " + employee.Account + " Password: " + employee.Password + " Name: " + employee.Name);

            Console.WriteLine("======================Delete===========================");

            repository.Delete(394809834);

            user = repository.Read();

            foreach (Employee item in user)
            {
                Console.WriteLine("Id: " + item.Id + " Account: " + item.Account + " Password: " + item.Password + " Name: " + item.Name);
            }
        }
    }
}
