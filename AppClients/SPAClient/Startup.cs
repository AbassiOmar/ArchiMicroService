using HealthChecks.UI.Client;
using IdentityModel;
using LoggingLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SPAClient.Services;
using System;

namespace SPAClient
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
            services.AddControllersWithViews();
            services.AddTransient<LoggingDelegatingHandler>();

            services.AddHttpClient<IProductService, ProductService>(c =>
              c.BaseAddress = new Uri(Configuration["ApiUrls:GatewayUri"]))
                 .AddHttpMessageHandler<LoggingDelegatingHandler>();

            services.AddHttpClient<IBasketService, BasketService>(c =>
             c.BaseAddress = new Uri(Configuration["ApiUrls:GatewayUri"]))
                .AddHttpMessageHandler<LoggingDelegatingHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SAP BackEnd", Version = "v1" });
            });

            services.AddHealthChecks();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
             .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
             {
                 //options.Authority = "https://localhost:5001";

                options.Authority = "http://192.168.55.15:5001";

                 options.ClientId = "spaclientApp";
                 options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
                 options.ResponseType = "code";
                 options.Scope.Clear();
                 options.Scope.Add("openid");
                 options.Scope.Add("profile");
                 options.Scope.Add("offline_access");
                 options.Scope.Add("productApi");
                 options.Scope.Add("offline_access");
                 options.UsePkce = true;
                 options.ClaimActions.DeleteClaim("sid");
                 options.ClaimActions.DeleteClaim("idp");
                 options.ClaimActions.DeleteClaim("s_hash");
                 options.ClaimActions.DeleteClaim("auth_time");
                 options.ClaimActions.MapUniqueJsonKey("role", "role");

               
                 options.SaveTokens = true;
                 options.GetClaimsFromUserInfoEndpoint = true;
                
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     NameClaimType = JwtClaimTypes.GivenName,
                     RoleClaimType = JwtClaimTypes.Role
                 };
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SPA Backend v1"));

            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //app.UseOpenIdConnectAuthentication(
            //  new OpenIdConnectAuthenticationOptions
            //  {
            //      ClientId = "testclient1",
            //      Authority = "https://localhost:44314/",
            //      ClientSecret = "client_secret_webform",
            //      ResponseType = "id_token token",
            //      SaveTokens = true,
            //      RedirectUri = "http://localhost:54602/signin-oidc",
            //      PostLogoutRedirectUri = "http://localhost:54602/signin-oidc",

            //  });



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    // spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
