using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
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
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserProfileDetailDto> GetUserDetailByUserName(string userName)
        {
            using (var context = new NorthwindContext())
            {
                var article = from r in context.Articles
                                select new ArticleDetailDto
                                {
                                    Id=r.Id,
                                    Text=r.Text,
                                    Title=r.Title,
                                  UserName=r.UserName
                                };


                var photo = from t in context.ProfilePhotos
                            select new UserProfilePhoto
                            {

                                ImagePath=t.ImagePath,
                                UserName=t.UserName
                            };
                var result = from a in context.Users
                            
                             where a.UserName == userName
                             select new UserProfileDetailDto
                             {
                                 Id=a.Id,
                                 UserName = a.UserName,
                                 FirstName = a.FirstName,
                                 LastName = a.LastName,
                                 AboutMe = a.AboutMe,
                                 ProfilePhotoUrl =!(photo.Any(e=>e.UserName==a.UserName))? new List<UserProfilePhoto>() { new UserProfilePhoto { Id=0,ImagePath= "https://t4.ftcdn.net/jpg/02/15/84/43/360_F_215844325_ttX9YiIIyeaR7Ne6EaLLjMAmy4GvPC69.jpg", UserName=a.UserName} } : photo.Where(e=>e.UserName==a.UserName).ToList(),
                                 ArticleDetail = !(article.Any(p => p.UserName == a.UserName)) 
                                     ? null
                                     : article.Where(p => p.UserName == a.UserName).ToList()


                             };
                return result.ToList();
                             
            }
            }

    } }
