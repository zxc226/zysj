using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("FILE", Schema = "public")]
    public class FILE
    {
        [Key]
        [Required]
        public Guid FID { get; set; }
        public string FNAME { get; set; }
        public Guid FUSER { get; set; }
        public DateTime FDATE { get; set; }
        public string FTYPE { get; set; }
        public string FBZ { get; set; }
    }
}
