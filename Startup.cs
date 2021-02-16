using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using QuestionQL.DataAccess;
using QuestionQL.GrqphQL;
using GraphQL.Server.Ui.Voyager;

namespace questionQL
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration){
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
                _configuration.GetConnectionString("QuestionDb")
            ));

            services
            .AddGraphQLServer()
            .AddQueryType<Query>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //adding graphql to the request pipeline
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions(){
               GraphQLEndPoint = _configuration["GraphQL:Endpont"],
               Path = _configuration["GraphQL:VoyagerEndpoint"]
            });
        }
    }
}
