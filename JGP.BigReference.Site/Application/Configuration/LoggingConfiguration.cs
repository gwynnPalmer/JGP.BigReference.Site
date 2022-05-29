// ***********************************************************************
// Assembly         : JGP.BigReference.Site
// Author           : Joshua Gwynn-Palmer
// Created          : 05-29-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 05-29-2022
// ***********************************************************************
// <copyright file="LoggingConfiguration.cs" company="JGP.BigReference.Site">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.BigReference.Site.Application.Configuration
{
    /// <summary>
    ///     Class LoggingConfiguration.
    /// </summary>
    internal static class LoggingConfiguration
    {
        /// <summary>
        ///     Configures the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appSettings">The application settings.</param>
        public static void Configure(IServiceCollection services, IConfiguration configuration, AppSettings appSettings)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                // Exceptionless or equivalent?
            });
        }
    }
}