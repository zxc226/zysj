using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZYSJModer.Moder
{
    [Table("zc", Schema = "public")]
    public class zc
    {
        [Key]
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public Guid UID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public string Name { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public string PHONE { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public string Email { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public string PWD { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释

        public string ZCYZM { get; set; }

    }
}
