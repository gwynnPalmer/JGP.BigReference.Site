// ***********************************************************************
// Assembly         : JGP.BigReference.Site
// Author           : Joshua Gwynn-Palmer
// Created          : 05-29-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 05-29-2022
// ***********************************************************************
// <copyright file="IocConfiguration.cs" company="JGP.BigReference.Site">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.BigReference.Site.Application.Configuration
{
    /// <summary>
    ///     Class IocConfiguration.
    /// </summary>
    internal static class IocConfiguration
    {
        /// <summary>
        ///     Configures the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appSettings">The application settings.</param>
        public static void Configure(IServiceCollection services, IConfiguration configuration, AppSettings appSettings)
        {
            services.AddSingleton(appSettings);
            services.AddSingleton(configuration);
        }
    }
}