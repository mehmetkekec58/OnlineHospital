using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class Fallow2Dto: IDto
    {
        public string FallowedUserName { get; set; }
        public string FallowingUserName { get; set; }
    }
}
