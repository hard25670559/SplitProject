using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database
{
    public class SingleDB
    {

        private static DB DB = null;

        private SingleDB() { }

        public static DB Instance()
        {

            if (SingleDB.DB == null)
            {
                SingleDB.DB = new DB();
            }

            return SingleDB.DB;
        }

    }
}
