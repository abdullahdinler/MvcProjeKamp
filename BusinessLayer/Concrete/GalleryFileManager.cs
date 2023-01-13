using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GalleryFileManager:IGalleryFileService
    {
        private IGalleryFileDal _galleryFileDal;

        public GalleryFileManager(IGalleryFileDal galleryFileDal)
        {
            _galleryFileDal = galleryFileDal;
        }

        public List<GalleryFile> GetList()
        {
            return _galleryFileDal.List();
        }

        public void Add(GalleryFile entity)
        {
            _galleryFileDal.Add(entity);
        }

        public void Delete(GalleryFile entity)
        {
            _galleryFileDal.Delete(entity);
        }

        public void Update(GalleryFile entity)
        {
            _galleryFileDal.Update(entity);
        }
    }
}
