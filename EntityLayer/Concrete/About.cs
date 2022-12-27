using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string Details { get; set; }
        [StringLength(500)]
        public string Details2 { get; set; }
        [StringLength(100)]
        public string Img { get; set; }
        [StringLength(100)]
        public string Img2 { get; set; }
    }
}
