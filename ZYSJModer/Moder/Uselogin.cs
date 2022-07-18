using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("Uselogin", Schema = "public")]
    public class Uselogin
    {
        [Key]
        [Required]
        public Guid UID { get; set; }
        public string Users { get; set; }
        public string PWD { get; set; }
        public Guid LV { get; set; }
        public Guid? STATE { get; set; }
    }
}
