using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SimpleInjector;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using HungryPizzaria.SDK.Core;
using HungryPizzaria.Ioc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Cors.Infrastructure;
using HungryPizzaria.Api.AutoMapper;

namespace HungryPizzaria.Api.Operation
{
    public class Startup
    {
        public Container container;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);


            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            var connectionstrings = new SDK.Core.Connections();
            new ConfigureFromConfigurationOptions<SDK.Core.Connections>(
                Configuration.GetSection("ConnectionStrings"))
                    .Configure(connectionstrings);
            services.AddSingleton(connectionstrings);
          

            var appSettingConfig = new AppSetting();
            new ConfigureFromConfigurationOptions<AppSetting>(
                Configuration.GetSection("AppSetting"))
                    .Configure(appSettingConfig);
            services.AddSingleton(appSettingConfig);                      

            var assembly = AppDomain.CurrentDomain.Load("HungryPizzaria.Application");
            services.AddMediatR(assembly);

            services.AddSwaggerGen(s =>
            {

                s.AddSecurityDefinition(
                    "Bearer",
                    new ApiKeyScheme()
                    {
                        In = "header",
                        Description = "Inserir o token Bearer",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                s.DescribeAllEnumsAsStrings();

                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "HungryPizzaria Operation",
                    Description = "HungryPizzaria API Swagger surface",
                    Contact = new Contact { Name = "Alexandre de Farias", Email = "alex_farias@msn.com", Url = "" },
                    License = new License { Name = "MIT", Url = "" }
                });
            });

            

            services.AddMvc()
                    .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddMvcCore();
            

            services.AddAutoMapper(x => x.AddProfile(new AutoMapperConfig()));
            // .NET Native DI Abstraction
            RegisterServices(services);




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors("SiteCorsPolicy");
            app.UseStaticFiles();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "HungryPizzaria Operation");
            });


        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            services.RegisterServices();

        }

        private void RegisterEventBusPedidoSeparacao(IServiceCollection services)
        {
            //var subscriptionClientName = "PedidoSeparacao";//Configuration["SubscriptionClientName"];

            //var IHandlerCommand = container.GetInstance<Dominio.Interfaces.Command.ISignIn>();

            //services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            //{
            //    var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
            //    var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
            //    var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
            //    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

            //    var retryCount = 5;
            //    if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
            //    {
            //        retryCount = int.Parse(Configuration["EventBusRetryCount"]);
            //    }

            //    return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount, IHandlerCommand);
            //});


            //services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            //services.AddTransient<Aplicacao.EventHandler.PedidoSeparacaoHandler>();

        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            //var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //Aqui configuro o dexpara da mensagem com o evento
            //eventBus.Subscribe<Domain.Events.Models.PedidoSeparacao, Application.EventHandler.PedidoSeparacaoHandler>();

        }
    }
}
