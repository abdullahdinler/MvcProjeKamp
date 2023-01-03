using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal:IRepository<Message>
    {
    }
}
