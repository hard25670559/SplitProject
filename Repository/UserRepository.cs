using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IRepository<object>
    {
        public bool Create(object model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, bool isSoft = false)
        {
            throw new NotImplementedException();
        }

        public List<object> Read()
        {
            throw new NotImplementedException();
        }

        public object Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, object model)
        {
            throw new NotImplementedException();
        }
    }
}
