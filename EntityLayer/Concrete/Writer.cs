using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SurName { get; set; }
        [StringLength(100)]
        public string Img { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        public string Password { get; set; }

        //Burada Writer sınıfı ile Heading sınıfı arasında bir ilişki kurduk.
        public ICollection<Heading> Headings { get; set; }

        //Burada Writer sınıfı ile Content sınıfı arasında bir ilişki kurduk.
        public ICollection<Content> Contents { get; set; }
    }
}
