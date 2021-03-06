using Escola.Data;
using Escola.Data.Interface;
using Escola.Data.Repository;
using Escola.Domain;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoEscola.API.AutoMapper;
using ProjetoEscola.API.Validators;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Escola
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
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            services.AddAutoMapper(typeof(ConfigurationMapping));

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            })
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            // Diferenças entre Transient, Scoped e Singleton (ciclos de vida):
            // Transient: sempre que for solicitado um objeto do conteiner de injeção de
            // dependência, um novo objeto será criado
            // Scoped: sempre que um escopo é criado, ele cria os objetos e os
            // reutiliza dentro daquele escopo
            // Singleton: Cria apenas uma instância que existirá enquanto a aplicação rodar, não importa o escopo,
            // é mais usado em apps desktop, para APIs é recomendado Scoped ou Transient
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IAulaRepository, AulaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<ITurmaProfessorRepository, TurmaProfessorRepository>();
            services.AddScoped<ITurmaAlunoRepository, TurmaAlunoRepository>();
            services.AddSingleton<ITesteSingletonRepository, TesteSingletonRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Opção para deixar a connection string nas configurações json:
            //services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration.GetConnectionString("Escola")));
            services.AddDbContext<Contexto>(options
                => options.UseSqlServer(
                    "Data Source=DESKTOP-JETDHQT\\SQLEXPRESS;Initial Catalog=Escola;Integrated Security=True"));

            // Swagger: conjunto de ferramentas desenvolvido para utilizar a OpenAPI (especificação
            // para descrever suas APIs) e tratar esta informação para expô-la
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Meu Projeto Escola",
                    Description = "Registra alunos, professores, turmas, aulas...",
                    TermsOfService = new Uri("https://go.microsoft.com/fwlink/?LinkID=206977"),
                    Contact = new OpenApiContact
                    {
                        Name = "Your name",
                        Email = string.Empty,
                        Url = new Uri("https://www.microsoft.com/learn")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var key = Encoding.ASCII.GetBytes(Configuracoes.Secret);
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                b.RequireHttpsMetadata = false;
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Escola");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
