using ConferencePlanner.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using ConferencePlanner.GraphQL.Schemas;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server;

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

            }, ServiceLifetime.Transient);

            services.AddTransient<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //GraphQL
            services.AddScoped<AppSchema>();

            services.AddGraphQL()
                    .AddSystemTextJson()
                    .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped);

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

            app.UseGraphQL<AppSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
