using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class Message2Dto:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string UserName { get; set; }
        public string ProfilPhoto { get; set; }
        public int OkunmayanMessage { get; set; }
        public bool IsOnline { get; set; }



    }
}
