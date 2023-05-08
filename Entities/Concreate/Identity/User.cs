﻿using Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Entities.Concreate.Identity
{
    public class User : IdentityUser<string>, IEntity 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
