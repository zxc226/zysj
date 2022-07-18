using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ZYSJDal;
using ZYSJModer.Moder;

namespace WebZYSJ_HT
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
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "HT API", Version = "v1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "ht API V2", Version = "v2" });
                //�������ע��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var commentsFileName = typeof(HT).Assembly.GetName().Name + ".XML";
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
