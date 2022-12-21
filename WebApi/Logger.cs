﻿using Serilog;
using System;
using System.Web;

namespace WebApi
{
    public static class Logger
    {
        private static readonly ILogger _errorLogger;

        static Logger()
        {
            _errorLogger = new LoggerConfiguration()
                .WriteTo.File(HttpContext.Current.Server.MapPath("~/logs/log-.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void LogError(Exception ex)
        {
            _errorLogger.Error(ex, "Exeption:");
        }

        public static void LogError(string error)
        {
            _errorLogger.Error(error);
        }
    }
}