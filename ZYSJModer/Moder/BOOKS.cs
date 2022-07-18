using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("BOOKS", Schema = "public")]
    public class BOOKS
    {
        [Key]
        [Required]
        public Guid BID { get; set; }
        public string BNAME { get; set; }
        public string BJJ { get; set; }
        public string BIMG { get; set; }
        public string BUNAME { get; set; }
        public DateTime BDATE { get; set; }
        public Guid BUID { get; set; }
    }
}
