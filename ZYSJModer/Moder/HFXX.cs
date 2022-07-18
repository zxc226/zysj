using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("HFXX", Schema = "public")]
    public class HFXX
    {
        [Key]
        [Required]
        public Guid HFID { get; set; }
        public Guid PID { get; set; }
        public string HFPL { get; set; }
        public int? DZNUM { get; set; }
        public Guid HFUSER { get; set; }
        public DateTime HFDATE { get; set; }
    }
}
