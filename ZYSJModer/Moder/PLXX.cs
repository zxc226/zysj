using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("PLXX", Schema = "public")]
    public class PLXX
    {
        [Key]
        [Required]
        public Guid PID { get; set; }
        public string PL { get; set; }
        public Guid PLHFID { get; set; }
        public int? DZNUM { get; set; }
        public Guid? PUSER { get; set; }
        public DateTime PDATE { get; set; }
        public Guid PLJLID { get; set; }
    }
}
