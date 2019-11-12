using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Unifiedban.Models;
using Unifiedban.Models.Group;

namespace Unifiedban.Data.Group
{
    public class ConfigurationParameterService
    {
        public ConfigurationParameter Add(ConfigurationParameter configurationParameter, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(configurationParameter);
                    ubc.SaveChanges();
                    return configurationParameter;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.ConfigurationParameterService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.ConfigurationParameterService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public ConfigurationParameter Update(ConfigurationParameter configurationParameter, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                ConfigurationParameter exists = ubc.Group_ConfigurationParameters
                    .Where(x => x.ConfigurationParameterId == configurationParameter.ConfigurationParameterId)
                    .FirstOrDefault();
                if (exists == null)
                    return null;

                try
                {
                    exists.Value = configurationParameter.Value;
                    exists.Type = configurationParameter.Type;
                    exists.Values = configurationParameter.Values;

                    ubc.SaveChanges();
                    return configurationParameter;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.ConfigurationParameterService.Update",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.ConfigurationParameterService.Update",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes Remove(ConfigurationParameter configurationParameter, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                ConfigurationParameter exists = ubc.Group_ConfigurationParameters
                    .Where(x => x.ConfigurationParameterId == configurationParameter.ConfigurationParameterId)
                    .FirstOrDefault();
                if (exists == null)
                    return SystemLog.ErrorCodes.Error;

                try
                {
                    ubc.SaveChanges();
                    return SystemLog.ErrorCodes.OK;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.ConfigurationParameterService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.ConfigurationParameterService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<ConfigurationParameter> Get(Expression<Func<ConfigurationParameter, bool>> whereClause)
        {
            using (UBContext ubc = new UBContext())
            {
                if (whereClause == null)
                    return ubc.Group_ConfigurationParameters
                        .AsNoTracking()
                        .ToList();

                return ubc.Group_ConfigurationParameters
                    .AsNoTracking()
                    .Where(whereClause)
                    .ToList();

            }
        }
    }
}
