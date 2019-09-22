﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Unifiedban.Models;
using Unifiedban.Models.Group;

namespace Unifiedban.Data.Group
{
    public class SafeGroupService
    {
        public SafeGroup Add(SafeGroup safeGroup, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(safeGroup);
                    ubc.SaveChanges();
                    return safeGroup;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.SafeGroupService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.SafeGroupService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes Remove(SafeGroup safeGroup, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                SafeGroup exists = ubc.Group_SafeGroups
                    .Where(x => x.TelegramChatId == safeGroup.TelegramChatId)
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
                        Function = "Unifiedban.Data.SafeGroupService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.SafeGroupService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<SafeGroup> Get(Expression<Func<SafeGroup, bool>> whereClause)
        {
            using (UBContext ubc = new UBContext())
            {
                if (whereClause == null)
                    return ubc.Group_SafeGroups
                        .AsNoTracking()
                        .ToList();

                return ubc.Group_SafeGroups
                    .AsNoTracking()
                    .Where(whereClause)
                    .ToList();

            }
        }
    }
}
