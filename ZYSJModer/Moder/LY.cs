using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("LY", Schema = "public")]
    public class LY
    {
        [Key]
        [Required]
        public Guid LID { get; set; }
        public string LYXX { get; set; }
        public string LYUSER { get; set; }
        public DateTime LYRQ { get; set; }
        public string Email { get; set; }
        public string LYTITLE { get; set; }
        public Guid LUID { get; set; }
        public string LTYPE { get; set; }
    }
}
