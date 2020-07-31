using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Net.Mime.MediaTypeNames;
using HungryPizzaria.Domain;
using HungryPizzaria.Application;

namespace HungryPizzaria.Ioc
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            RegisterRepositoryCore(services);
            RegisterComponents(services);
        }


        private static void RegisterRepositoryCore(this IServiceCollection services) {


            //Query
            services.AddScoped<HungryPizzaria.Domain.Operation.Querys.Projeto.IQueryCliente, HungryPizzaria.Application.Querys.Projeto.QueryCliente>();
            services.AddScoped<HungryPizzaria.Domain.Operation.Querys.Projeto.IQueryPedidos, HungryPizzaria.Application.Querys.Projeto.QueryPedidos>();
            services.AddScoped<HungryPizzaria.Domain.Operation.Querys.Projeto.IQueryItensPedido, HungryPizzaria.Application.Querys.Projeto.QueryItensPedido>();
            services.AddScoped<HungryPizzaria.Domain.Operation.Querys.Projeto.IQueryPizzaSabores, HungryPizzaria.Application.Querys.Projeto.QueryPizzaSabores>();





            // Repository Operation
            services.AddScoped<HungryPizzaria.Domain.Operation.Repository.Projeto.IClienteRepository, HungryPizzaria.Data.Operation.Repositories.Projeto.ClienteRepository>();
            services.AddScoped<HungryPizzaria.Domain.Operation.Repository.Projeto.IPedidosRepository, HungryPizzaria.Data.Operation.Repositories.Projeto.PedidosRepository>();
            services.AddScoped<HungryPizzaria.Domain.Operation.Repository.Projeto.IItensPedidoRepository, HungryPizzaria.Data.Operation.Repositories.Projeto.ItensPedidoRepository>();
            services.AddScoped<HungryPizzaria.Domain.Operation.Repository.Projeto.IPizzaSaboresRepository, HungryPizzaria.Data.Operation.Repositories.Projeto.PizzaSaboresRepository>();



        }

        public static void RegisterComponents(this IServiceCollection services) {           

        }

    }
}
