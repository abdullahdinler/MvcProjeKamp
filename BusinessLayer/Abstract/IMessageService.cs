using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInBox();
        List<Message> GetListSendBox();
        Message GetById(int id);
        void Add(Message entity);
        void Delete(Message entity);
        void Update(Message entity);
    }
}
