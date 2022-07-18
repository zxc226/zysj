using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("JDXX", Schema = "public")]
    public class JDXX
    {
        [Key]
        [Required]
        public Guid JDID { get; set; }
        public string JDNR { get; set; }
        public string JDING { get; set; }
        public Guid JDWJ { get; set; }
        public Guid CSID { get; set; }
        public DateTime JDDATE { get; set; }
        public string JDUSER { get; set; }
        public Guid JDUID { get; set; }
    }
}
