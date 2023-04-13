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
        private readonly IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public IMessageService GetByIdd(int id)
        {
            throw new NotImplementedException();
        }

        public List<IMessageService> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListByWriter(string m)
        {
            return _messagedal.GetAll(x => x.Sender == m);
        }

        public void TAdd(IMessageService t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(IMessageService t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(IMessageService t)
        {
            throw new NotImplementedException();
        }
    }
}
