using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("Users", Schema = "public")]
    public class Users
    {
        [Key]
        [Required]
        public Guid UID { get; set; }
        public string UNAME { get; set; }
        public string PHONE { get; set; }
        public Guid? DSF { get; set; }
        public string QQID { get; set; }
        public string ADR { get; set; }
        public string UQM { get; set; }
        public DateTime BDATE { get; set; }
        public string JOB { get; set; }
        public string AH { get; set; }
        public string UIMG { get; set; }
        public string BZ { get; set; }
        
        public string Email { get; set; }
        public string WORKPLACE { get; set; }
        public DateTime? BIRTHDAY { get; set; }
        public string NICK { get; set; }
        public string ZYM { get; set; }
        public string SPECIAALIZED { get; set; }
    }
}
