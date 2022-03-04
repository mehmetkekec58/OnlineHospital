using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FallowManager : IFallowService
    {
        IFallowDal _fallowDal;

        public FallowManager(IFallowDal fallowDal)
        {
            _fallowDal = fallowDal;
        }

        public IResult Fallow(Fallow fallow)
        {
            IResult result = BusinessRules.Run(CheckIfAlreadyFallowedSamePerson(fallow.FallowedUserName, fallow.FallowingUserName));
            if (result != null)
            {
                return result;
            }
            _fallowDal.Add(fallow);
            return new SuccessResult(Messages.UserFallowed);
        }

        public IDataResult<FallowedCount> FallowedCount(string userName)
        {
            return new SuccessDataResult<FallowedCount>(_fallowDal.FallowedCount(userName));
        }

        public IResult isFallowing(Fallow fallow)
        {
            IResult result = BusinessRules.Run(CheckIfAlreadyFallowedSamePerson(fallow.FallowedUserName, fallow.FallowingUserName));
            if (result != null)
            {
              //  var Result1 = _fallowDal.GetList(p => p.FallowedUserName == fallow.FallowedUserName && p.FallowingUserName == fallow.FallowingUserName).ToList().ToString();
                return new SuccessResult("1");
            }
            return new SuccessResult("0");
        }

        public IResult UnFallowed(Fallow fallow)
        {
            /* Fallow2Dto fallow3 = new Fallow2Dto();
             fallow3.FallowedUserName = fallow.FallowedUserName;
             fallow3.FallowingUserName = fallow.FallowingUserName;*/
            var Result1 = _fallowDal.GetList(p => p.FallowedUserName == fallow.FallowedUserName && p.FallowingUserName == fallow.FallowingUserName).ToArray();
         
                Fallow fallow3 = new Fallow();
            fallow3.Id = Result1[0].Id;
            fallow3.FallowedUserName = fallow.FallowedUserName;
            fallow3.FallowingUserName = fallow.FallowingUserName;
            _fallowDal.Delete(fallow3);
            return new SuccessResult(Messages.UnFallowedUser);
        }
        private IResult CheckIfAlreadyFallowedSamePerson(string FedUserName, string FingUserName)
        {
          
            
            var Result = _fallowDal.GetList(p=>p.FallowedUserName==FedUserName && p.FallowingUserName==FingUserName).Count;
            return Result>=1 ? new ErrorResult(Messages.AlreadyFallowedSamePerson):new SuccessResult();
        }
    }
 
}
