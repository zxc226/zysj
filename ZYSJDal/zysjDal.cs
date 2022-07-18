using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZYSJModer.Moder;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Collections.Generic;

namespace ZYSJDal
{
    public class zysjDal : DbContext
    {
        public zysjDal()
        {

        }
        public zysjDal(DbContextOptions<zysjDal> options) : base(options)
        {
            Database.EnsureCreated();//不存在表时会创建
        }

        public DbSet<Uselogin> Uselogin { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<BOOKS> BOOKS { get; set; }
        public DbSet<CSXX> CSXX { get; set; }
        public DbSet<FILE> FILE { get; set; }
        public DbSet<HFXX> HFXX { get; set; }
        public DbSet<JDXX> JDXX { get; set; }
        public DbSet<JL> JL { get; set; }
        public DbSet<LY> LY { get; set; }
        public DbSet<PLXX> PLXX { get; set; }
        public DbSet<VIDES> VIDES { get; set; }
        public DbSet<Dictionary> Dictionary { get; set; }
        public DbSet<XXTX> XXTX { get; set; }
        public DbSet<SC> SC { get; set; }

        /// <summary>
        /// 重写父类的方法 用于连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //连接字符串
                optionsBuilder.UseNpgsql("User ID=Administrator;Password=123456789;Host=localhost;Port=5432;Database=ZYSJ;Pooling=false;");
                
            }

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static string CeackToken()
        {
            Random rd = new Random();
            var bb = "";
            List<string> ts = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                int aa = Convert.ToInt32(rd.Next(10000, 99999).ToString());
                ts.Add(aa.ToString("x4"));
            }
            for (int i = 0; i < ts.Count; i++)
            {
                bb += ts[i].ToString();
            }
            return bb;
        }

        /// <summary>
        /// 创建令牌
        /// </summary>
        /// <param name="claims">指定参数</param>
        /// <returns></returns>
        public static string GenerateToken(Claim[] claims)
        {
            //创建一个加密秘钥（长度在16位以上）——需和Startup类中Jwt配置中设置的秘钥一样
            var secret = CeackToken();
            //把秘钥字符串转换成字节数组，创建新的安全键实例
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            //使用安全键实例创建一个关键的信息，用什么加密算法
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //安全令牌指定参数
            var token = new JwtSecurityToken(
                "MyAdmin",//发行者——需和Startup类中Jwt配置中设置的颁发者一样
                "MyUser",//访问者——需和Startup类中Jwt配置中设置的访问者一样
                claims,
                expires: DateTime.Now.AddHours(0.5),//令牌过期时间
                signingCredentials: credentials);
            //创建Json Web令牌,安全令牌变成一个小型的JWT序列化格式。
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
