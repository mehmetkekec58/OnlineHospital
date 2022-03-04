using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class FallowDetailDto :IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<UserProfilePhoto> Photo  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FallowedUserName { get; set; }
        public string FallowingUserName { get; set; }
        public string AboutMe { get; set; }
        public int UserId { get; set; }


    }
}
