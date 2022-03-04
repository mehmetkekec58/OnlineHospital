using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserProfilePhoto
    {

        IResult Add(IFormFile file, UserProfilePhoto userProfilePhoto);
        IResult Delete(UserProfilePhoto userProfilePhoto);
        IResult Update(IFormFile file, UserProfilePhoto userProfilePhoto);
        IDataResult<UserProfilePhoto> Get(int userPhotoId);
        IDataResult<List<UserProfilePhoto>> GetAll();
        IDataResult<List<UserProfilePhoto>> GetImagesByCarId(string userName);


    }
}
