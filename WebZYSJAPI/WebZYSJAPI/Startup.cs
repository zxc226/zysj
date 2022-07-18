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
                    // ��֤�䷢��
                    ValidateIssuer = true,
                    // ��֤������
                    ValidateAudience = true,
                    // ��֤������
                    ValidateLifetime = true,
                    // ��֤ʹ���ߵ�ǩ����Կ
                    ValidateIssuerSigningKey = true,
                    // ���ð䷢��
                    ValidIssuer = "MyAdmin",
                    // ���÷�����
                    ValidAudience = "MyUser",
                    //����֤������������ʱ�䵽���������ڣ�Ĭ�ϵ���300��
                    //Ĭ����300�룬Ҳ����5���Ӻ󣬼��������������õ���30�룬����Ҫ������300��
                    ClockSkew = TimeSpan.Zero,
                    //������Կ------�������ƶԳư�ȫ��Կ����ʵ��
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("873D82D99180B30807F4DA6893369D88"))

                };
                // �����֤������̵Ŀ�������¼�
                options.Events = new JwtBearerEvents()
                {
                    // ��һ���յ�Э����Ϣʱ����
                    OnMessageReceived = context =>
                    {
                        //������ͷ�л�ȡtoken
                        string token = context.Request.Headers["token"];
                        //token�Ƿ�Ϊ���ַ���null���߿հ��ַ�
                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            context.Token = token;//�����õ�token����Զ���֤
                        }
                        return Task.CompletedTask;
                    },
                    // �ڽ���ѯ���͸��ص���֮ǰ���ã�Ȩ����֤ʧ�ܺ󴥷���
                    OnChallenge = context =>
                    {
                        // ��ֹ.NET CoreĬ�ϵķ������ͺͽ��
                        context.HandleResponse();
                        // �Զ��巵�ؽ��
                        var myResult = JsonConvert.SerializeObject(new { code = 401, msg = "��Ǹ������Ȩ���ʣ�" });
                        // �Զ��巵����������
                        context.Response.ContentType = "applic/json";
                        // �Զ��巵��״̬�루Ĭ��Ϊ200��(������ĳ�401)
                        context.Response.StatusCode = StatusCodes.Status305UseProxy;
                        //���json���ݽ��
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
            //����Swagger
            services.AddSwaggerGen(options =>
              {
                  options.SwaggerDoc("v1", new OpenApiInfo { Title = "ZYSJ API", Version = "v1" });
                  options.SwaggerDoc("v2", new OpenApiInfo { Title = "zysj API V2", Version = "v2" });
                  //�������ע��
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
            // ���������֤(����ֻ��Ҫ�������)
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            //�����м����������Swagger
            app.UseSwagger();
            //�����м����������SwaggerUI��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web ZYSJ V1");
                c.RoutePrefix = string.Empty;//���ø��ڵ����
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
