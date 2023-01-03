using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Txt { get; set; }
        public bool Status { get; set; }
        public DateTime DateTimee { get; set; }

        //Burada Content sınıfı ile Heading sınıfı arasında bir ilişki kurduk.
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }


        //Burada Writer sınıfı ile Content sınıfı arasında bir ilişki kurduk.

        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
