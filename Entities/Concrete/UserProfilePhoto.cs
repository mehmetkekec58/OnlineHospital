using Core.Entities;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserProfilePhoto:IEntity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
       
        public string UserName { get; set; }

    }
}
