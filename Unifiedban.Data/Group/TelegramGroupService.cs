/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

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
    public class TelegramGroupService
    {
        public TelegramGroup Add(TelegramGroup telegramGroup, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(telegramGroup);
                    ubc.SaveChanges();
                    return telegramGroup;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.TelegramGroupService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.TelegramGroupService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public TelegramGroup Update(TelegramGroup telegramGroup, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                TelegramGroup exists = ubc.Group_TelegramGroups
                    .Where(x => x.GroupId == telegramGroup.GroupId)
                    .FirstOrDefault();
                if (exists == null)
                    return null;

                try
                {
                    exists.TelegramChatId = telegramGroup.TelegramChatId;
                    exists.Title = telegramGroup.Title;
                    exists.State = telegramGroup.State;
                    exists.Configuration = telegramGroup.Configuration;
                    exists.WelcomeText = telegramGroup.WelcomeText;
                    exists.ChatLanguage = telegramGroup.ChatLanguage;
                    exists.SettingsLanguage = telegramGroup.SettingsLanguage;
                    exists.ReportChatId = telegramGroup.ReportChatId;
                    exists.RulesText = telegramGroup.RulesText;
                    exists.InviteAlias = telegramGroup.InviteAlias;
                    exists.InviteLink = telegramGroup.InviteLink;

                    ubc.SaveChanges();
                    return telegramGroup;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.TelegramGroupService.Update",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.TelegramGroupService.Update",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes Remove(TelegramGroup telegramGroup, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                TelegramGroup exists = ubc.Group_TelegramGroups
                    .Where(x => x.GroupId == telegramGroup.GroupId)
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
                        Function = "Unifiedban.Data.TelegramGroupService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.TelegramGroupService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<TelegramGroup> Get(Expression<Func<TelegramGroup, bool>> whereClause)
        {
            try
            {
                using (UBContext ubc = new UBContext())
                {
                    if (whereClause == null)
                        return ubc.Group_TelegramGroups
                            .AsNoTracking()
                            .ToList();

                    return ubc.Group_TelegramGroups
                        .AsNoTracking()
                        .Where(whereClause)
                        .ToList();

                }
            }
            catch
            {
                return new List<TelegramGroup>();
            }
        }
    }
}
