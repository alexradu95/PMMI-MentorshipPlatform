using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Entities
{
    public abstract class AbstractEntity
    {

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IdentityUser CreatedBy { get; set; }
        public IdentityUser ModifiedBy { get; set; }

    }
}
