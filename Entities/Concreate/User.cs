using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class User:IEntity
    { 
        public int ID { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age{ get; set; }

    }
}
