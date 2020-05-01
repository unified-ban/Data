/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using Unifiedban.Models;

namespace Unifiedban.Data.Utils
{
    public class Logging
    {
        private static Dictionary<string, ILog> loggers = new Dictionary<string, ILog>();
        public static bool Initialized { get; private set; } = false;

        public void Initialize(string loggerName, string basePath)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            GlobalContext.Properties["LogName"] = "Unifiedban-Terminal";
            GlobalContext.Properties["BasePath"] = basePath;
            XmlConfigurator.Configure(logRepository, new FileInfo(basePath + "/log4net.config"));

            ILog newLogger = LogManager.GetLogger(logRepository.Name, loggerName);
            loggers.Add(loggerName, newLogger);
            newLogger = LogManager.GetLogger(logRepository.Name, "NotInitializedLogger");
            loggers.Add("NotInitializedLogger", newLogger);

            Initialized = true;
        }

        public static void AddLog(SystemLog log, bool logToDB = false)
        {
            if (log.LoggerName == null)
                log.LoggerName = "NotInitializedLogger";

            switch (log.Level)
            {
                case SystemLog.Levels.Debug:
                    LogDebug(log, logToDB);
                    break;
                case SystemLog.Levels.Info:
                    LogInfo(log, logToDB);
                    break;
                case SystemLog.Levels.Warn:
                    LogWarn(log, logToDB);
                    break;
                case SystemLog.Levels.Error:
                    LogError(log, logToDB);
                    break;
                case SystemLog.Levels.Fatal:
                    LogFatal(log, logToDB);
                    break;
                default:

                    break;
            }
        }
        public static void LogDebug(string function, string message, int userId = -1,
            bool logToDB = false, string loggerName = "Unifiedban-Terminal")
        {
            if (!loggers.ContainsKey(loggerName))
                loggerName = "NotInitializedLogger";
            if (!loggers[loggerName].IsDebugEnabled)
                return;

            SystemLog log = new SystemLog()
            {
                LoggerName = loggerName,
                Function = function,
                Message = message,
                UserId = userId,
                Date = DateTime.Now,
                Level = SystemLog.Levels.Debug
            };

            LogDebug(log, logToDB);
        }
        public static void LogDebug(SystemLog log, bool logToDB = false)
        {
            if (!loggers.ContainsKey(log.LoggerName))
                log.LoggerName = "NotInitializedLogger";
            if (!loggers[log.LoggerName].IsDebugEnabled)
                return;

            string message = String.Format("#°° {0} °°# {1} §", log.Function, log.Message);
            loggers[log.LoggerName].Debug(message);
            if (logToDB)
                LogToDb(log);
        }
        public static void LogInfo(string function, string message, int userId = -1,
            bool logToDB = false, string loggerName = "Unifiedban-Terminal")
        {
            if (!loggers.ContainsKey(loggerName))
                loggerName = "NotInitializedLogger";
            if (!loggers[loggerName].IsInfoEnabled)
                return;

            SystemLog log = new SystemLog()
            {
                LoggerName = loggerName,
                Function = function,
                Message = message,
                UserId = userId,
                Date = DateTime.Now,
                Level = SystemLog.Levels.Info
            };

            LogInfo(log, logToDB);
        }
        public static void LogInfo(SystemLog log, bool logToDB = false)
        {
            if (!loggers.ContainsKey(log.LoggerName))
                log.LoggerName = "NotInitializedLogger";
            if (!loggers[log.LoggerName].IsInfoEnabled)
                return;

            string message = String.Format("#°° {0} °°# {1} §", log.Function, log.Message);
            loggers[log.LoggerName].Info(message);
            if (logToDB)
                LogToDb(log);
        }
        public static void LogWarn(string function, string message, int userId = -1,
            bool logToDB = false, string loggerName = "Unifiedban-Terminal")
        {
            if (!loggers.ContainsKey(loggerName))
                loggerName = "NotInitializedLogger";
            if (!loggers[loggerName].IsWarnEnabled)
                return;

            SystemLog log = new SystemLog()
            {
                LoggerName = loggerName,
                Function = function,
                Message = message,
                UserId = userId,
                Date = DateTime.Now,
                Level = SystemLog.Levels.Warn
            };

            LogWarn(log, logToDB);
        }
        public static void LogWarn(SystemLog log, bool logToDB = false)
        {
            if (!loggers.ContainsKey(log.LoggerName))
                log.LoggerName = "NotInitializedLogger";
            if (!loggers[log.LoggerName].IsWarnEnabled)
                return;

            string message = String.Format("#°° {0} °°# {1} §", log.Function, log.Message);
            loggers[log.LoggerName].Warn(message);
            if (logToDB)
                LogToDb(log);
        }
        public static void LogError(string function, string message, int userId = -1,
            bool logToDB = false, string loggerName = "Unifiedban-Terminal")
        {
            if (!loggers.ContainsKey(loggerName))
                loggerName = "NotInitializedLogger";
            if (!loggers[loggerName].IsErrorEnabled)
                return;

            SystemLog log = new SystemLog()
            {
                LoggerName = loggerName,
                Function = function,
                Message = message,
                UserId = userId,
                Date = DateTime.Now,
                Level = SystemLog.Levels.Error
            };

            LogError(log, logToDB);
        }
        public static void LogError(SystemLog log, bool logToDB = false)
        {
            if (!loggers.ContainsKey(log.LoggerName))
                log.LoggerName = "NotInitializedLogger";
            if (!loggers[log.LoggerName].IsErrorEnabled)
                return;

            string message = String.Format("#°° {0} °°# {1} §", log.Function, log.Message);
            loggers[log.LoggerName].Error(message);
            if (logToDB)
                LogToDb(log);
        }
        public static void LogFatal(string function, string message, int userId = -1,
            bool logToDB = false, string loggerName = "Unifiedban-Terminal")
        {
            if (!loggers.ContainsKey(loggerName))
                loggerName = "NotInitializedLogger";
            if (!loggers[loggerName].IsFatalEnabled)
                return;

            SystemLog log = new SystemLog()
            {
                LoggerName = loggerName,
                Function = function,
                Message = message,
                UserId = userId,
                Date = DateTime.Now,
                Level = SystemLog.Levels.Fatal
            };

            LogFatal(log, logToDB);
        }
        public static void LogFatal(SystemLog log, bool logToDB = false)
        {
            if (!loggers.ContainsKey(log.LoggerName))
                log.LoggerName = "NotInitializedLogger";
            if (!loggers[log.LoggerName].IsFatalEnabled)
                return;

            string message = String.Format("#°° {0} °°# {1} §", log.Function, log.Message);
            loggers[log.LoggerName].Fatal(message);
            if (logToDB)
                LogToDb(log);
        }
        public static void LogToDb(string function, string message, int userId = -1,
            SystemLog.Levels level = SystemLog.Levels.Error, string loggerName = "Unifiedban-Terminal")
        {
            return;
        }
        public static void LogToDb(SystemLog log)
        {
            return;
        }
    }
}
