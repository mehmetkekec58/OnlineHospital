using Business.Abstract;
using Business.Constants;
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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public IDataResult<MessageDto> GetAllMessages(string alan, string gonderen)
        {
            return new SuccessDataResult<MessageDto>(_messageDal.GetAllMessage(alan, gonderen));
        }

        public IDataResult<List<Message2Dto>> GetListUser(string userName)
        {
            return new SuccessDataResult<List<Message2Dto>>(_messageDal.GetUserMessage(userName));
        }

        public IResult send(Message message)
        {
       _messageDal.Add(message);
       return new SuccessResult(Messages.MessageSended);
        }
    }
}
