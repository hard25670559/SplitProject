using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Repository
{
    public abstract class Repository : IRepository
    {

        protected DbContext DB { get; set; }

        public Repository()
        {
            
        }

        public abstract bool Create(Model model);
        public abstract bool Delete(int id, bool isSoft = false);
        public abstract List<Model> Read();
        public abstract Model Read(int id);
        public abstract bool Update(int id, Model model);
    }
}
