using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IFallowService
    {
        IResult Fallow(Fallow fallow);
        IResult UnFallowed(Fallow fallow);
        IDataResult<FallowedCount> FallowedCount(string userName);
        IResult isFallowing(Fallow fallow);
    }
}
