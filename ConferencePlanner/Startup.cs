using ConferencePlanner.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL;
using MediatR;
using System.Reflection;
//using ConferencePlanner.GraphQL.DataLoader;
//using ConferencePlanner.GraphQL.Types;

namespace ConferencePlanner {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ConferencePlanner", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("ConferencePlannerDb");
            services.AddDbContext<ApplicationDbContext>((serviceProvider, optionsBuilder) => {
                optionsBuilder.UseNpgsql(connectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
                optionsBuilder.UseApplicationServiceProvider(serviceProvider);
            });


            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //GraphQL
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddFiltering();
                //.AddType<SpeakerType>()
                //.AddDataLoader<SpeakerByIdDataLoader>();
                //.AddDataLoader<SessionByIdDataLoader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConferencePlanner v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
        }
    }
}
