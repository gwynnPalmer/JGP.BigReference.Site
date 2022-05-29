// ***********************************************************************
// Assembly         : JGP.BigReference.Site
// Author           : Joshua Gwynn-Palmer
// Created          : 05-29-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 05-29-2022
// ***********************************************************************
// <copyright file="SecurityConfiguration.cs" company="JGP.BigReference.Site">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.BigReference.Site.Application.Configuration
{
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.CookiePolicy;

    /// <summary>
    ///     Class SecurityConfiguration.
    /// </summary>
    public static class SecurityConfiguration
    {
        /// <summary>
        ///     Configures the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureCookieOptions(services);
            //services.AddAuthentication();
            //services.AddAuthorization();
            //services.AddApiAuthentication(configuration);
            services.AddAuthorization();
        }

        /// <summary>
        ///     Configures the cookie options.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void ConfigureCookieOptions(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy =
                    SameSiteMode.Lax; //changed due to Google / OAuth2 not working with Strict.
                options.HttpOnly = HttpOnlyPolicy.Always; //Server Use Only
                options.Secure = CookieSecurePolicy.Always; //If not dev then always secure delivery only
            });
        }

        /// <summary>
        ///     Adds the authentication.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void AddAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.AccessDeniedPath = new PathString("/Home/Forbidden/");
                    options.LoginPath = "/security/login/";
                    options.Cookie.Name = "big-reference-user";
                });
        }

        /// <summary>
        ///     Adds the authorization.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void AddAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(CookieAuthenticationDefaults.AuthenticationScheme,
                    policy => { policy.RequireAuthenticatedUser(); });

                options.AddPolicy("SystemAdmin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    //policy.RequireRole();
                });
            });
        }

        /// <summary>
        ///     Adds the API authentication.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        private static void AddApiAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<ApiConfiguration>(options =>
            //    configuration.GetSection(ApiConfiguration.ConfigurationSectionName).Bind(options));
        }
    }
}