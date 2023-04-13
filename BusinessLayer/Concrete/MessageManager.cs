using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        readonly IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public Message GetByIdd(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListByWriter(string m)
        {
            return _messagedal.GetAll(x => x.Sender == m);
        }

        public List<Message> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Message t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
