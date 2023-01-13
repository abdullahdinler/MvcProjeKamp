using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager: IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(x => x.Id == id);
        }

        public List<Message> GetListInBox()
        {
            return _messageDal.List();
        }

      
        public List<Message> GetListSendBox()
        {
            return _messageDal.List();
        }

       
        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
        
    }
}
