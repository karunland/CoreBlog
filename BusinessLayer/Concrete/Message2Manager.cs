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
    public class Message2Manager : IMessage2Service
    {
        readonly IMessage2Dal _message2dal;

        public Message2Manager(IMessage2Dal message2dal)
        {
            _message2dal = message2dal;
        }
        public List<Message2> GetInboxListByWriter(int id)
        {
            return _message2dal.GetInboxMessageByWriter(id);
        }
        public Message2 GetByIdd(int id)
        {
            return _message2dal.GetById(id);
        }

        public List<Message2> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Message2 t)
        {
            _message2dal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetSendboxListByWriter(int id)
        {
            return _message2dal.GetSendboxMessageByWriter(id);
        }
    }
}
