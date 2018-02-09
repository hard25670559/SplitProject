using Core.Models;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class UserRepository : IRepository
    {

        public List<Model> User = new List<Model>();

        public UserRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                this.User.Add(new User
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
            return this.User;
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
