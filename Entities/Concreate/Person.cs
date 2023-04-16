using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class Person:IEntity
    { 
        public int PersonID { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age{ get; set; }

    }
}
