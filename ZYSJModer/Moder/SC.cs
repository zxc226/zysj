using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZYSJModer.Moder
{
    [Table("SC", Schema = "public")]
    public class SC
    {
        [Key]
        public Guid SCID { get; set; }
        public Guid SCNRID { get; set; }
        public Guid SCTYPE { get; set; }
        public Guid SCUSER { get; set; }
        public DateTime SCDATE { get; set; }
    }
}
