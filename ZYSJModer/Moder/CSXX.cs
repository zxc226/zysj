using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("CSXX", Schema = "public")]
    public class CSXX
    {
        [Key]
        [Required]
        public Guid XSID { get; set; }
        public string XSXX { get; set; }
        public string BZ { get; set; }
        public string XSIMG { get; set; }
        public DateTime XSDATE { get; set; }
        public Guid XSWJ { get; set; }
        public Guid XSTYPE { get; set; }
    }
}
