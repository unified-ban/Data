﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

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
    public class BannedService
    {
        public Banned Add(Banned banned, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    using (var transaction = ubc.Database.BeginTransaction())
                    {
                        try
                        {
                            ubc.Add(banned);
                            ubc.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.User_Banned ON;");
                            ubc.SaveChanges();
                            ubc.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.User_Banned OFF");
                            transaction.Commit();

                            return banned;
                        }
                        catch (Exception ex)
                        {
                            Utils.Logging.AddLog(new SystemLog()
                            {
                                LoggerName = "Unifiedban",
                                Date = DateTime.Now,
                                Function = "Unifiedban.Data.BannedService.Add",
                                Level = SystemLog.Levels.Warn,
                                Message = ex.Message,
                                UserId = callerId
                            });
                            if (ex.InnerException != null)
                                Utils.Logging.AddLog(new SystemLog()
                                {
                                    LoggerName = "Unifiedban.Data",
                                    Date = DateTime.Now,
                                    Function = "Unifiedban.Data.BannedService.Add",
                                    Level = SystemLog.Levels.Warn,
                                    Message = ex.InnerException.Message,
                                    UserId = callerId
                                });

                            return null;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.BannedService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.BannedService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes Remove(Banned banned, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                Banned exists = ubc.Users_Banned
                    .Where(x => x.TelegramUserId == banned.TelegramUserId)
                    .FirstOrDefault();
                if (exists == null)
                    return SystemLog.ErrorCodes.Error;

                try
                {
                    ubc.Remove(exists);
                    ubc.SaveChanges();
                    return SystemLog.ErrorCodes.OK;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.BannedService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.BannedService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<Banned> Get(Expression<Func<Banned, bool>> whereClause)
        {
            try
            {
                using (UBContext ubc = new UBContext())
                {
                    if (whereClause == null)
                        return ubc.Users_Banned
                            .AsNoTracking()
                            .ToList();

                    return ubc.Users_Banned
                        .AsNoTracking()
                        .Where(whereClause)
                        .ToList();

                }
            }
            catch
            {
                return new List<Banned>();
            }
        }
        
        public List<Banned> GetLimit(Expression<Func<Banned, bool>> whereClause, int limit)
        {
            try
            {
                using (UBContext ubc = new UBContext())
                {
                    if (whereClause == null)
                        return ubc.Users_Banned
                            .AsNoTracking()
                            .OrderByDescending(x => x.UtcDate).Skip(0).Take(limit)
                            .ToList();

                    return ubc.Users_Banned
                        .AsNoTracking()
                        .Where(whereClause)
                        .OrderByDescending(x => x.UtcDate).Skip(0).Take(limit)
                        .ToList();

                }
            }
            catch
            {
                return new List<Banned>();
            }
        }
    }
}
