using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("VIDES", Schema = "public")]
    public class VIDES
    {
        [Key]
        [Required]
        public Guid VID { get; set; }
        public string VNAME { get; set; }
        public int? VSC { get; set; }
        public string VIMG { get; set; }
        public string URL { get; set; }
        public DateTime VDATE { get; set; }
        public string VUSER { get; set; }
        public Guid VUID { get; set; }
    }
}
