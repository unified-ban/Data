using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Unifiedban.Models;

namespace Unifiedban.Data
{
    public class SysConfigService
    {
        public SysConfig Add(SysConfig sysConfig, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(sysConfig);
                    ubc.SaveChanges();
                    return sysConfig;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.SysConfigService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.SysConfigService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SysConfig Update(SysConfig sysConfig, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                SysConfig exists = ubc.SysConfigs
                    .Where(x => x.SysConfigId == sysConfig.SysConfigId)
                    .FirstOrDefault();
                if (exists == null)
                    return null;

                try
                {
                    exists.Value = sysConfig.Value;

                    ubc.SaveChanges();
                    return sysConfig;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.SysConfigService.Update",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.SysConfigService.Update",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes Remove(SysConfig sysConfig, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                SysConfig exists = ubc.SysConfigs
                    .Where(x => x.SysConfigId == sysConfig.SysConfigId)
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
                        Function = "Unifiedban.Data.SysConfigService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.SysConfigService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<SysConfig> Get(Expression<Func<SysConfig, bool>> whereClause)
        {
            try
            {
                using (UBContext ubc = new UBContext())
                {
                    if (whereClause == null)
                        return ubc.SysConfigs
                            .AsNoTracking()
                            .ToList();

                    return ubc.SysConfigs
                        .AsNoTracking()
                        .Where(whereClause)
                        .ToList();

                }
            }
            catch
            {
                return new List<SysConfig>();
            }
        }
    }
}
