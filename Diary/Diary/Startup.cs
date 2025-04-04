using AutoMapper;
using Diary.Consumers;
using Diary.DataAccess;
using Diary.Mapping;
using Diary.MiddleWares;
using Diary.Settings;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using FluentValidation;
using Diary.Validators;
using Diary.GRPC.Services;
using Grpc.Core;
using GrpcDiary;
using Grpc.Net;
using Grpc.AspNetCore;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.Tcp;
using Diary.Middlewares;

namespace Diary
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private const string Origin = "DiarySpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {       
            var connectionString = Environment.GetEnvironmentVariable("diary_connection_db_string");
            var corsConfig       = Configuration.GetSection("CorsSettings").Get<CorsSettings>();

            services.AddDbContext<EfDbContext>(optionsBuilder
               => optionsBuilder
                   .UseNpgsql(connectionString));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
            });        

            services.AddCors(options =>
            {
                options.AddPolicy(name: Origin,
                                  build =>
                                  {
                                      build.WithOrigins(corsConfig.Origins)
                                      .WithMethods(corsConfig.Methods)
                                      .WithHeaders(corsConfig.Headers);
                                  });
            });

            InstallAutomapper(services);

            services.AddServices(Configuration);
            services.AddControllers();
            services.AddHealthChecks().AddCheck<DiaryHealthCheck>("diaryHealth", tags: new string[] { "diaryHealthCheck" });
            services.AddServices(Configuration);
            services.AddControllers();
            services.AddFluentValidationAutoValidation();
            services.AddValidators();
     
            services.AddGrpc();
            services.AddScoped<GRPC.Services.DiaryGrpcService>();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.ListenAnyIP(5001, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2;
                });

                options.ListenAnyIP(5000, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1;
                });
            });    

            services.AddMassTransit(configurator =>
            {
                configurator.SetKebabCaseEndpointNameFormatter();
                //configurator.AddConsumer<CreateDiaryLineFromMagazineConsumer>();
                configurator.AddConsumer<RoomDesignerStartingRoomConsumer>();

                configurator.UsingRabbitMq((context, cfg) =>
                {
                    var rmqSettings = Configuration.Get<ApplicationSettings>()!.RmqSettings;
                    cfg.Host(rmqSettings.Host,
                                rmqSettings.VHost,
                                h =>
                                {
                                    h.Username(rmqSettings.Login);
                                    h.Password(rmqSettings.Password);
                                });
                   cfg.ConfigureEndpoints(context);
                });
            });

          
            services.AddOpenApiDocument(options =>
            {
                options.Title   = "Diary API doc";
                options.Version = "1.0";
            });

            ConfigureLogging(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseLoggingMiddleware();
            app.UseCors(Origin);
            app.UseOpenApi();
            app.UseSwaggerUi(x =>
            {
                x.DocExpansion = "list";
            });

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseHealthChecks("/diaryHealth", new HealthCheckOptions(){
                Predicate = healthCheck => healthCheck.Tags.Contains("diaryHealthCheck")
            });
              
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<GRPC.Services.DiaryGrpcService>();
            });

        }

        private static IServiceCollection InstallAutomapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<HabitDiaryOwnerMappingsProfile>();
                cfg.AddProfile<HabitDiaryMappingsProfile>();
                cfg.AddProfile<HabitDiaryLineMappingsProfile>();
                cfg.AddProfile<HabitMappingsProfile>();
                cfg.AddProfile<HabitStateMappingsProfile>();
            });

            configuration.AssertConfigurationIsValid();
            return configuration;
        }

        private void ConfigureLogging(IServiceCollection services)
        {
            var elasticsearchUrl = Environment.GetEnvironmentVariable("SERILOG_ELASTICSEARCH_URL");
            var logstashUrl = Environment.GetEnvironmentVariable("SERILOG_LOGSTASH_URL");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "Diary")
                .Enrich.WithMachineName()
                .WriteTo.Console()
                .WriteTo.File(
                    path: "logs/diary-log.json",
                    rollingInterval: RollingInterval.Day,
                    formatter: new CompactJsonFormatter())
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUrl))
                {
                    BatchPostingLimit = 1, 
                    Period = TimeSpan.FromSeconds(1), 
                    AutoRegisterTemplate = true,
                    IndexFormat = "diary-logs-{0:yyyy.MM.dd}",
                    ModifyConnectionSettings = x => x.ServerCertificateValidationCallback(
                        (o, certificate, arg3, arg4) => true) 
                })
               .WriteTo.TcpSink(
                    uri: $"tcp://{logstashUrl.Split(':')[0]}:{logstashUrl.Split(':')[1]}",
                    formatter: new CompactJsonFormatter())
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog();
            });
        }

    }
}
