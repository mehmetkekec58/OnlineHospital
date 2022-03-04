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
    public class EfFallowDal : EfEntityRepositoryBase<Fallow, NorthwindContext>, IFallowDal
    {

        public FallowedCount FallowedCount(string username)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var FallowedResult = from a in context.Fallows
                             
                             where a.FallowedUserName == username
                             select new Fallow
                             {
                                 Id = a.Id,
                                 FallowedUserName = a.FallowedUserName,
                                 FallowingUserName = a.FallowingUserName
                             };
                var FallowedCountResult=FallowedResult.ToList().Count;

                var FallowedUserName = FallowedResult.ToList();

                var FallowingResult = from b in context.Fallows
                                       where b.FallowingUserName == username
                                       select new Fallow
                                       {
                                           Id = b.Id,
                                           FallowingUserName = b.FallowingUserName,
                                           FallowedUserName = b.FallowedUserName
                                       };
                var FallowingCountResult = FallowingResult.ToList().Count;
              var  FallowingUserName = FallowingResult.ToList();
             var AllResult=  new FallowedCount
                {
                    FedCount = FallowedCountResult,
                    FingCount = FallowingCountResult,
                   FedList = !(FallowedResult.Any(p => p.FallowedUserName == username))
                                     ? null
                                     : FallowedResult.Where(p => p.FallowedUserName == username).ToList(),
                  FingList= !(FallowingResult.Any(p => p.FallowingUserName == username))
                                     ? null
                                     : FallowingResult.Where(p => p.FallowingUserName == username).ToList()
             };
                return AllResult;


                }
            }
        }
    }


