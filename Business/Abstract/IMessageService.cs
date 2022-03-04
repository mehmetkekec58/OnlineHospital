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
   public interface IMessageService
    {
        IResult send(Message message);
        IResult Delete(Message message);

        IDataResult<MessageDto> GetAllMessages(string alan, string gonderen);
        IDataResult<List<Message2Dto>> GetListUser(string userName);

       // IDataResult<UserProfileDetailDto> GetUser()
    }
}
