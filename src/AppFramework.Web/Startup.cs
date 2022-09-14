using AppFramework.Data.Repository;
using AppFramework.Data.RepositoryInterface;
using AppFramework.Service.Service;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility.AutoMapper;
using AppFramework.Utility.ErrorLog;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AppFramework.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "AppFramework.Web", Version = "v2" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
            });
            });

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddCors();

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );

            //Add Service user Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };

               options.Events = new JwtBearerEvents();
               options.Events.OnChallenge = context =>
               {
                   // Skip the default logic.
                   context.HandleResponse();

                   var payload = new JObject
                   {
                       ["statusCode"] = 401,
                       ["status"] = true,
                       ["message"] = "Unauthorized user",
                       ["resultData"] = null,
                       ["resourceType"] = ""
                   };

                   return context.Response.WriteAsync(payload.ToString());
               };
           });

            ResolveDependency(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory _loggerFactory)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "AppFramework.Web v2"));
            }

            var logger = _loggerFactory.CreateLogger("Startup");
            logger.LogInformation("Got Here in Startup");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration["CORS:AllowedOriginsList"])
                       .WithHeaders(Configuration["CORS:AllowedHeadersList"])
                       .WithMethods(Configuration["CORS:AllowedMethodsList"]);
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Add services in container
        /// </summary>
        /// <param name="services"></param>
        public void ResolveDependency(IServiceCollection services)
        {
            services.AddTransient<ILogError, LogError>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<IFeatureService, FeatureService>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<ICitizenRepository, CitizenRepository>();
            services.AddTransient<ICitizenService, CitizenService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<IDistrictService, DistrictService>();

            services.AddTransient<IWorkflowProcessService, WorkflowProcessService>();
            services.AddTransient<IWorkflowProcessRepository, WorkflowProcessRepository>();
            services.AddTransient<IWorkflowStageActionRepository, WorkflowStageActionRepository>();
            services.AddTransient<IWorkflowStageActionService, WorkflowStageActionService>();
            services.AddTransient<IWorkflowStageRepository, WorkflowStageRepository>();
            services.AddTransient<IWorkflowStageService, WorkflowStageService>();

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            services.AddTransient<IAdminLoginRepository, AdminLoginRepository>();
            services.AddTransient<IAdminLoginService, AdminLoginService>();
            services.AddTransient<INavigationService, NavigationService>();
            services.AddTransient<INavigationRepository, NavigationRepository>();

            services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
            services.AddTransient<IRolePermissionService, RolePermissionService>();
            services.AddTransient<IRoleNavigationRepository, RoleNavigationRepository>();
            services.AddTransient<IRoleNavigationService, RoleNavigationService>();
            services.AddTransient<IEmployeeRoleMappingRepository, EmployeeRoleMappingRepository>();
            services.AddTransient<IEmployeeRoleMappingService, EmployeeRoleMappingService>();

            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IProfileService, ProfileService>();
              
            services.AddTransient<IRelievingRepository, RelievingRepository>();
            services.AddTransient<IRelievingService,RelievingService>();
            
            
            services.AddTransient<IBlobService, BlobService>();

            services.AddTransient<ILogService, LogService>();
            services.AddTransient<ILogRepository, LogRepository>();

          

            var serviceProvider = services.BuildServiceProvider();
        }
    }
}


