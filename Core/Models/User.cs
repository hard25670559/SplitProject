using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Models
{
    public class User : Model
    {

        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

    }
}