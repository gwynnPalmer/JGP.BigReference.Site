// ***********************************************************************
// Assembly         : JGP.BigReference.Site
// Author           : Joshua Gwynn-Palmer
// Created          : 05-29-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 05-29-2022
// ***********************************************************************
// <copyright file="Startup.cs" company="JGP.BigReference.Site">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.BigReference.Site
{
    using Application.Configuration;

    /// <summary>
    ///     Class Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        ///     Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options => { });

            var appSettings = new AppSettings();
            Configuration.GetSection(AppSettings.ConfigurationSectionName).Bind(appSettings);
            SecurityConfiguration.Configure(services, Configuration);
            IocConfiguration.Configure(services, Configuration, appSettings);
            LoggingConfiguration.Configure(services, Configuration, appSettings);

            services.AddHealthChecks();

            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        ///     Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var exceptionlessClient = new ExceptionlessClient(appSettings.ExceptionLessKey);
            //exceptionlessClient.Configuration.DefaultTags.Add(env.EnvironmentName);
            //app.UseExceptionless(exceptionlessClient);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                app.UseExceptionHandler("/error/500");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseHealthChecks("/health");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("AreaRouting", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}