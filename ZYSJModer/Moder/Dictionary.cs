using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    [Table("Dictionary", Schema = "public")]
    public class Dictionary
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    {
        [Key]
        [Required]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public Guid ZDID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public int? ZDTYPE { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public string ZDNAME { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    }
}
