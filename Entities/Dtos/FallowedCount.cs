using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class FallowedCount:IDto
    {
        public int FedCount { get; set; }
        public int FingCount { get; set; }

       public List<Fallow> FedList { get; set; }
        public List<Fallow> FingList { get; set; }

    }
}
