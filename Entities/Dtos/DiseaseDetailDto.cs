using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class DiseaseDetailDto:IDto
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
