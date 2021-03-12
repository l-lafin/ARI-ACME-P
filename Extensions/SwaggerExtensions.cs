using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace DemoAcmeApp.Extensions
{
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Método para adição e configuração de instâncias swagger em aplicações WEB API.
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Acme Producer (AP) REST API",
                    Description = "Lista de serviços da empresa Acme para integração",
                    Version = "Versão API 1.0",
                    License = new OpenApiLicense
                    {
                        Name = "MIT - ACME License"
                    },
                    Contact = new OpenApiContact
                    {
                        Name = "Acme",
                        Email = "support@acme.com"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
            });
        }
    }
}
