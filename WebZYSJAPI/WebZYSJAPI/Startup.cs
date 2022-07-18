using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ZYSJDal;
using ZYSJModer.Moder;

namespace WebZYSJAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=> {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    // 验证颁发者
                    ValidateIssuer = true,
                    // 验证访问者
                    ValidateAudience = true,
                    // 验证生存期
                    ValidateLifetime = true,
                    // 验证使用者的签名秘钥
                    ValidateIssuerSigningKey = true,
                    // 设置颁发者
                    ValidIssuer = "MyAdmin",
                    // 设置访问者
                    ValidAudience = "MyUser",
                    //在验证令牌生命周期时间到后，立即过期；默认的是300秒
                    //默认是300秒，也就是5分钟后，假如生命周期设置的是30秒，还需要加上这300秒
                    ClockSkew = TimeSpan.Zero,
                    //设置秘钥------返回令牌对称安全密钥的新实例
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("873D82D99180B30807F4DA6893369D88"))

                };
                // 身份验证处理过程的控制相关事件
                options.Events = new JwtBearerEvents()
                {
                    // 第一次收到协议消息时调用
                    OnMessageReceived = context =>
                    {
                        //从请求头中获取token
                        string token = context.Request.Headers["token"];
                        //token是否为空字符，null或者空白字符
                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            context.Token = token;//这里拿到token后会自动验证
                        }
                        return Task.CompletedTask;
                    },
                    // 在将资询发送给回调者之前调用（权限验证失败后触发）
                    OnChallenge = context =>
                    {
                        // 终止.NET Core默认的返回类型和结果
                        context.HandleResponse();
                        // 自定义返回结果
                        var myResult = JsonConvert.SerializeObject(new { code = 401, msg = "抱歉，您无权访问！" });
                        // 自定义返回数据类型
                        context.Response.ContentType = "applic/json";
                        // 自定义返回状态码（默认为200）(我这里改成401)
                        context.Response.StatusCode = StatusCodes.Status305UseProxy;
                        //输出json数据结果
                        context.Response.WriteAsync(myResult);
                        return Task.FromResult(0);
                    },
                };
              

            });
            services.AddCors(options =>
            {
                options.AddPolicy("all", builder =>
                {
                    builder.SetIsOriginAllowed(options => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    //.WithMethods("GET", "POST")
                    .AllowCredentials();
                });
            });

            services.AddControllers();
            //配置Swagger
            services.AddSwaggerGen(options =>
              {
                  options.SwaggerDoc("v1", new OpenApiInfo { Title = "ZYSJ API", Version = "v1" });
                  options.SwaggerDoc("v2", new OpenApiInfo { Title = "zysj API V2", Version = "v2" });
                  //添加中文注释
                  var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                  var commentsFileName = typeof(JcbApplicationModule).Assembly.GetName().Name + ".XML";
                  var xmlPath = Path.Combine(basePath, commentsFileName);
                  options.IncludeXmlComments(xmlPath);

                  options.DocInclusionPredicate((docName, description) => true);
              });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc(options => { options.EnableEndpointRouting = false; });

            services.AddDbContext<zysjDal>(opt => opt.UseNpgsql(Configuration.GetConnectionString("todoContext")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("all");
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            // 启用身份验证(我们只需要启用这个)
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            //启用中间件服务生成Swagger
            app.UseSwagger();
            //启用中间件服务生成SwaggerUI，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web ZYSJ V1");
                c.RoutePrefix = string.Empty;//设置根节点访问
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
