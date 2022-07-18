using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("JL", Schema = "public")]
    public class JL
    {
        [Key]
        [Required]
        public Guid JID { get; set; }
        public string JTITLE { get; set; }
        public string JLXX { get; set; }
        public string JLIMG { get; set; }
        public Guid JUSER { get; set; }
        public DateTime DATE { get; set; }
        public Guid? PID { get; set; }
        public int? DZNUM { get; set; }
    }
}
