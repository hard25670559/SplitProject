using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Setting
    {
        public enum Alias
        {
            User,
            Employee
        }

        public static Dictionary<Alias, Type> RepositoryDictionary = new Dictionary<Alias, Type>
        {
            {Alias.User, typeof(UserRepository) },
            {Alias.Employee, typeof(EmployeeRepository) }
        };

    }
}
