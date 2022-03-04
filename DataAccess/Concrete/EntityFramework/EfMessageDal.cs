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
    public class EfMessageDal : EfEntityRepositoryBase<Message, NorthwindContext>, IMessageDal
    {
        public List<Message2Dto> GetUserMessage(string userName)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result2 = from a in context.Messages
                              where a.AlanUserName == userName && a.IsRead == false
                              select new Message
                              {
                                  Id = a.Id,
                                  GonderenUserName = a.GonderenUserName,
                                  AlanUserName = a.AlanUserName,
                                  Date = a.Date,
                                  IsRead = a.IsRead,
                                  Text = a.Text


                              };
                var result3 = result2.ToList().Count();


                var result7 = from a in context.Messages
                              where a.GonderenUserName == userName && a.IsRead == false
                              select new Message
                              {
                                  Id = a.Id,
                                  GonderenUserName = a.GonderenUserName,
                                  AlanUserName = a.AlanUserName,
                                  Date = a.Date,
                                  IsRead = a.IsRead,
                                  Text = a.Text


                              };
                var birlesim = result7.Concat(result2);

                var result = from a in context.Messages
                             join b in context.ProfilePhotos
                             on a.AlanUserName equals b.UserName
                             join c in context.Users
                             on b.UserName equals c.UserName
                           orderby c.Id ascending 
                             select new Message2Dto
                             {
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 UserName = c.UserName,
                                 ProfilPhoto = b.ImagePath,
                                 IsOnline = c.Status,
                                 OkunmayanMessage =result3,

                             };
            
               
                return result.ToList();
            }
           
        }

        public MessageDto GetAllMessage(string alan, string gonderen)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var result = from a in context.Messages
                             where a.AlanUserName == alan && a.GonderenUserName == gonderen
                             select new Message
                             {
                                 Id=a.Id,
                                 AlanUserName=a.AlanUserName,
                                 GonderenUserName=a.GonderenUserName,
                                 Date=a.Date,
                                 Text=a.Text,
                                 IsRead=a.IsRead
                                
                             };
                var list = result.ToList();

                var result2 = from b in context.Messages
                              where b.AlanUserName == gonderen && b.GonderenUserName == alan
                              select new Message
                              {
                                  Id = b.Id,
                                  AlanUserName = b.AlanUserName,
                                  GonderenUserName = b.GonderenUserName,
                                  Date = b.Date,
                                  Text = b.Text,
                                  IsRead=b.IsRead
                                  
                              };

                var list2 = result2.ToList();

                var resultAll = new MessageDto
                {
                    BizimGonderdigimiz= !(list.Any(p => p.GonderenUserName == gonderen && p.AlanUserName==alan))
                                     ? null
                                     : list.Where(p => p.GonderenUserName == gonderen && p.AlanUserName==alan).ToList(),
                    OnunGonderdigi= !(list2.Any(p => p.AlanUserName == gonderen && p.GonderenUserName==alan))
                                     ? null
                                     : list2.Where(p => p.AlanUserName == gonderen && p.GonderenUserName==alan).ToList(),
                
                };

                return resultAll;
            }


        }
    }
}
