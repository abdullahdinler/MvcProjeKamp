using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGalleryFileService
    {
        List<GalleryFile> GetList();
        void Add(GalleryFile entity);
        void Delete(GalleryFile entity);
        void Update(GalleryFile entity);
    }
}
