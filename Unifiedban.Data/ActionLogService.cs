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
    public class ActionLogService
    {
        public ActionLog Add(ActionLog actionLog, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(actionLog);
                    ubc.SaveChanges();
                    return actionLog;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.ActionLogService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.ActionLogService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }

        public List<ActionLog> Get(Expression<Func<ActionLog, bool>> whereClause)
        {
            try
            {
                using (UBContext ubc = new UBContext())
                {
                    if (whereClause == null)
                        return ubc.ActionLogs
                            .AsNoTracking()
                            .ToList();

                    return ubc.ActionLogs
                        .AsNoTracking()
                        .Where(whereClause)
                        .ToList();

                }
            }
            catch
            {
                return new List<ActionLog>();
            }
        }
    }
}
