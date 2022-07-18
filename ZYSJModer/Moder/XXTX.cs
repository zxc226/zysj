using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZYSJModer.Moder
{
    [Table("XXTX", Schema = "public")]
    public class XXTX
    {
        [Key]
        [Required]
        public Guid TXID { get; set; }
        public Guid FSUID { get; set; }
        public string FSNR { get; set; }
        public DateTime FSDATE { get; set; }
        public Guid JSUID { get; set; }
        public Guid FSFILE { get; set; }
    }
}
