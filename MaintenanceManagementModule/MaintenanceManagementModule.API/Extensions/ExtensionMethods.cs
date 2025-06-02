namespace MaintenanceManagementModule.API.Extensions
{
    public static class ExtensionMethods
    {
        // CORS Configuration
        public static void ConfigureCors(this IServiceCollection serviceCollection, string policy)
        {
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy(policy,
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // Swagger Configuration
        public static void ConfigureSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                //Adding JWT Auth Support in Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer token."
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
        }

        // App Settings Configuration
        public static void ConfigureAppSetting(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<AppSetting>(configuration.GetSection("AppSetting"));
        }
      
        // Sql Server Configuration
        public static void ConfigureSqlServer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppDbContext>(o => o.UseSqlServer(configuration["AppSetting:ConnectionString"]));
        }

        // Identity Configuration
        public static void ConfigureIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentity<UserEntity, IdentityRole>(config =>
            {
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            serviceCollection.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });
        }

        // Authentication Configuration
        public static void ConfigureAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSetting:JWTSecret"].ToString())),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // Service Configuration
        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            RegisterServices.ConfigureServices(serviceCollection);
        }

    }
}
