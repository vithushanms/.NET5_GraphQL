using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using QuestionQL.DataAccess;
using QuestionQL.GrqphQL;
using GraphQL.Server.Ui.Voyager;
using QuestionQL.GrqphQL.Questions;
using QuestionQL.GrqphQL.Answers;

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
            /*AddPooledDbContextFactory is method introduced in .NET 5 to handle parallel executions*/
            services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(
                _configuration.GetConnectionString("QuestionDb")
            ));

            services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddType<QuestionType>()
            .AddType<AnswerType>();
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
                /*adding graphql to the request pipeline*/
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
               GraphQLEndPoint = _configuration["GraphQL:Endpont"],
               Path = _configuration["GraphQL:VoyagerEndpoint"]
            });
        }
    }
}
