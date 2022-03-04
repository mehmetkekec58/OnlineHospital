using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class MessageDto:IDto
    {
        public List<Message> OnunGonderdigi { get; set; }
        public List<Message> BizimGonderdigimiz { get; set; }
    }
}
