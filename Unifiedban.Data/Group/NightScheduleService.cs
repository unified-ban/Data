using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Unifiedban.Models;
using Unifiedban.Models.Group;

namespace Unifiedban.Data.Group
{
    public class NightScheduleService
    {
        public NightSchedule Add(NightSchedule nightSchedule, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(nightSchedule);
                    ubc.SaveChanges();
                    return nightSchedule;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.NightScheduleService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.NightScheduleService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public NightSchedule Update(NightSchedule nightSchedule, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                NightSchedule exists = ubc.Group_NightSchedules
                    .Where(x => x.NightScheduleId == nightSchedule.NightScheduleId)
                    .FirstOrDefault();
                if (exists == null)
                    return null;

                try
                {
                    exists.State = nightSchedule.State;
                    exists.UtcStartDate = nightSchedule.UtcStartDate;
                    exists.UtcEndDate = nightSchedule.UtcEndDate;

                    ubc.SaveChanges();
                    return nightSchedule;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.NightScheduleService.Update",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.NightScheduleService.Update",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes Remove(NightSchedule nightSchedule, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                NightSchedule exists = ubc.Group_NightSchedules
                    .Where(x => x.NightScheduleId == nightSchedule.NightScheduleId)
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
                        Function = "Unifiedban.Data.NightScheduleService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.NightScheduleService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<NightSchedule> Get(Expression<Func<NightSchedule, bool>> whereClause)
        {
            using (UBContext ubc = new UBContext())
            {
                if (whereClause == null)
                    return ubc.Group_NightSchedules
                        .AsNoTracking()
                        .ToList();

                return ubc.Group_NightSchedules
                    .AsNoTracking()
                    .Where(whereClause)
                    .ToList();

            }
        }
    }
}
