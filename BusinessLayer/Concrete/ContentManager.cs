using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDal _content;

        public ContentManager(IContentDal content)
        {
            _content = content;
        }

        public void Add(Content entity)
        {
            _content.Add(entity);
        }

        public void Delete(Content entity)
        {
            _content.Delete(entity);
        }

        public Content GetById(int id)
        {
            var c = _content.GetById(x => x.Id == id);
            return c;
        }

        public List<Content> GetList()
        {
            var c = _content.List();
            return c;
        }

        public List<Content> GetListById(int id)
        {
            var c = _content.List(x => x.HeadingId == id);
            return c;
        }

        public List<Content> GetListContent(int id)
        {
            var c = _content.List(x => x.WriterId == id);
            return c;
        }

        public List<Content> Search(string word)
        {
            return _content.List(x => x.Txt.Contains(word));
        }

        public void Update(Content entity)
        {
            _content.Update(entity);
        }
    }
}
