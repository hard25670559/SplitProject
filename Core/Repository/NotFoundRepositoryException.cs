using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class NotFoundRepositoryException : Exception
    {

        public override string Message => "未找到任何Repository.";

    }
}
