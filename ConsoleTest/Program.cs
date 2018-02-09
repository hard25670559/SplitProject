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

            List<Model> user = RepositoryFactory.Repository(Alias.Employee).Read();

            foreach (Employee item in user)
            {
                Console.WriteLine("Id: " + item.Id + " Account: " + item.Account + " Password: " + item.Password + " Name: " + item.Name);
            }

        }
    }
}
