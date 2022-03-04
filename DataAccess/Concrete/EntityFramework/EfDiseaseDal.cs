using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDiseaseDal : EfEntityRepositoryBase<Disease, NorthwindContext>, IDiseaseDal
    {
        public List<DiseaseDetailDto> GetDiseaseDetail(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Users
                             join c in context.Diseases
                             on p.Id equals c.UserId where c.Id==id
                             select new DiseaseDetailDto
                             {                       
                                 FirstName = p.FirstName,
                                 LastName = p.LastName,
                                 Title = c.Title,
                                 Text = c.Text,
                                 PublishedDate = c.PublishedDate
                             };
                return result.ToList();
            }
        }
    }
}
