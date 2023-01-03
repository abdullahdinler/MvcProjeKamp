using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string UserMail { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }
        public DateTime DateTimee { get; set; }
    }
}
