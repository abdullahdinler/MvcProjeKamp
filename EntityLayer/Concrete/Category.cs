using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool Status { get; set; }

        // Burada Category sınıfı ile Heading sınıfı arasında bir ilişki kurduk.
        public ICollection<Heading> Headings { get; set; } 
    }
}
