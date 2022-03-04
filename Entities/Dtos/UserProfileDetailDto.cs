using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class UserProfileDetailDto:IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutMe { get; set; }
        public List<UserProfilePhoto> ProfilePhotoUrl { get; set; }
        public List<ArticleDetailDto> ArticleDetail { get; set; }






    }
}
