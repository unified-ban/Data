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

namespace Unifiedban.Data
{
    public class SupportSessionLogService
    {
        public SupportSessionLog Add(SupportSessionLog supportSessionLog, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(supportSessionLog);
                    ubc.SaveChanges();
                    return supportSessionLog;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.SupportSessionLogService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }public List<SupportSessionLog> Add(List<SupportSessionLog> supportSessionLog, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(supportSessionLog);
                    ubc.SaveChanges();
                    return supportSessionLog;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.SupportSessionLogService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }

        public List<SupportSessionLog> Get(Expression<Func<SupportSessionLog, bool>> whereClause)
        {
            try
            {
                using (UBContext ubc = new UBContext())
                {
                    if (whereClause == null)
                        return ubc.SupportSessionLogs
                            .AsNoTracking()
                            .ToList();

                    return ubc.SupportSessionLogs
                        .AsNoTracking()
                        .Where(whereClause)
                        .ToList();

                }
            }
            catch
            {
                return new List<SupportSessionLog>();
            }
        }
    }
}
