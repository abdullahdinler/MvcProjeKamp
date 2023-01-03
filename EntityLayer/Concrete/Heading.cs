using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime DateTimee { get; set; }
        public bool Status { get; set; }

        //Burada Writer sınıfı ile Heading sınıfı arasında bir ilişki kurduk.
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        // Burada Category sınıfı ile Heading sınıfı arasında bir ilişki kurduk.
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Burada Heading sınıfı ile Content sınıfı arasında bir ilişki kurduk.
        public ICollection<Content> Contents { get; set; }
    }
}
