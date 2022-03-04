using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserProfilePhotoManager:IUserProfilePhoto
    {
         IUserProfilePhotoDal _userProfilePhotoDal;
         IFileHelper _fileHelper;

        public UserProfilePhotoManager(IUserProfilePhotoDal userProfilePhotoDal, IFileHelper fileHelper)
        {
            _userProfilePhotoDal = userProfilePhotoDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, UserProfilePhoto userProfilePhoto)
        {
            var imageCount = _userProfilePhotoDal.GetAll(c => c.UserName == userProfilePhoto.UserName).Count;

            if (imageCount >= 1)
            {
                return new ErrorResult("One from profile must have 1 or less images");
            }

            var imageResult = _fileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            userProfilePhoto.ImagePath = imageResult.Message;
            _userProfilePhotoDal.Add(userProfilePhoto);
            return new SuccessResult(Messages.UserProfilePhotoAdded);
        }

        public IDataResult<UserProfilePhoto> Get(int id)
        {
            return new SuccessDataResult<UserProfilePhoto>(_userProfilePhotoDal.Get(c => c.Id == id));
        }

        public IDataResult<List<UserProfilePhoto>> GetAll()
        {
            return new SuccessDataResult<List<UserProfilePhoto>>(_userProfilePhotoDal.GetAll());
        }


        public IDataResult<List<UserProfilePhoto>> GetImagesByCarId(string userName)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(userName));

            if (result != null)
            {
                return new ErrorDataResult<List<UserProfilePhoto>>(result.Message);
            }

            return new SuccessDataResult<List<UserProfilePhoto>>(CheckIfCarImageNull(userName).Data);
        }

        public IResult Delete(UserProfilePhoto userProfilePhoto)
        {
            var image = _userProfilePhotoDal.Get(c => c.Id == userProfilePhoto.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }
            _fileHelper.Delete(image.ImagePath);
            _userProfilePhotoDal.Delete(userProfilePhoto);
            return new SuccessResult("Image was deleted successfully");
        }
        public IResult Update(IFormFile file, UserProfilePhoto userProfilePhoto)
        {
            var isImage = _userProfilePhotoDal.Get(c => c.Id == userProfilePhoto.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = _fileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            userProfilePhoto.ImagePath = updatedFile.Message;
            _userProfilePhotoDal.Update(userProfilePhoto);
            return new SuccessResult("Profile photo updated");
        }


        private IDataResult<List<UserProfilePhoto>> CheckIfCarImageNull(string userName)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _userProfilePhotoDal.GetAll(c => c.UserName == userName).Any();
                if (!result)
                {
                    List<UserProfilePhoto> carimage = new List<UserProfilePhoto>();
                    carimage.Add(new UserProfilePhoto {ImagePath = path , UserName=userName});
                    return new SuccessDataResult<List<UserProfilePhoto>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<UserProfilePhoto>>(exception.Message);
            }

            return new SuccessDataResult<List<UserProfilePhoto>>(_userProfilePhotoDal.GetAll(c => c.UserName == userName).ToList());
        }
    }
}
