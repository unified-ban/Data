using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Unifiedban.Models;
using Unifiedban.Models.User;

namespace Unifiedban.Data.User
{
    public class TempKickedService
    {
        public TempKicked Add(TempKicked tempKicked, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(tempKicked);
                    ubc.SaveChanges();
                    return tempKicked;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.TempKickedService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.TempKickedService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes Remove(TempKicked tempKicked, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                TempKicked exists = ubc.Users_TempKicked
                    .Where(x => x.GroupId == tempKicked.GroupId
                        && x.TelegramUserId == tempKicked.TelegramUserId)
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
                        Function = "Unifiedban.Data.TempKickedService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.TempKickedService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<TempKicked> Get(Expression<Func<TempKicked, bool>> whereClause)
        {
            using (UBContext ubc = new UBContext())
            {
                if (whereClause == null)
                    return ubc.Users_TempKicked
                        .AsNoTracking()
                        .ToList();

                return ubc.Users_TempKicked
                    .AsNoTracking()
                    .Where(whereClause)
                    .ToList();

            }
        }
    }
}
