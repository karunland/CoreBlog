﻿using BusinessLayer.Abstract;
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
        public List<Message2> GetInboxListByWriter(int m)
        {
            return _message2dal.GetAll(x => x.RecieverId == m);
        }
        public Message2 GetByIdd(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
