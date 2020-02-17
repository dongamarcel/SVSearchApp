using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repositories;
using Repositories.Model;
using Services;
using Services.Configuration;
using SimonsVoss.Infra.Concretes;
using SimonsVoss.Infra.Factory;
using SimonsVoss.Infra.Interfaces;

namespace SearchApi
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
            services.AddControllers();
            services.AddHttpClient();
            DependencyFactory.Instance.AddScoped<IDeserializer>(typeof(JsonDeserializer));
            DependencyFactory.Instance.AddScoped<ISearchRepository>(typeof(SearchRepository));
            DependencyFactory.Instance.AddSingleton<ISearchDataProvider>(new SearchDataProvider(Configuration.GetValue<string>(WebHostDefaults.ContentRootKey)));
            DependencyFactory.Instance.AddScoped<ISearchWeightRepository>(typeof(SearchWeightRepository));
            DependencyFactory.Instance.AddScoped<ISearchWeightConfiguration>(typeof(SearchWeightConfiguration));
            DependencyFactory.Instance.AddScoped<ISearchService>(typeof(SearchService));
            DependencyFactory.Instance.AddTransient<ISearchResult>(typeof(SearchResult));
            DependencyFactory.Instance.AddTransient<ISearchConfiguration>(typeof(DefaultSearchConfiguration));
            DependencyFactory.Instance.Init();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
