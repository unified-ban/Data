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
using Unifiedban.Models.User;

namespace Unifiedban.Data
{
    public class DashboardSessionService
    {
        /// <summary>
        /// Creates a new DashboardSession
        /// </summary>
        /// <param name="dashboardSession"></param>
        /// <param name="callerId"></param>
        /// <returns>DashboardSession or Response</returns>
        public object Add(DashboardSession dashboardSession, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(dashboardSession);
                    ubc.SaveChanges();

                    return dashboardSession;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.DashboardSessionService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                    {
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.DashboardSessionService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                    }
                }

                return new Response()
                {
                    StatusCode = 4006,
                    StatusDescription = "Error creating DashboardSession on database."
                };
            }
        }
        public SystemLog.ErrorCodes Remove(DashboardSession dashboardSession, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                DashboardSession exists = ubc.DashboardSessions
                    .Where(x => x.DashboardSessionId == dashboardSession.DashboardSessionId
                        && x.DashboardUserId == dashboardSession.DashboardUserId
                        && x.DeviceId == dashboardSession.DeviceId)
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
                        Function = "Unifiedban.Data.DashboardSessionService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.DashboardSessionService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<DashboardSession> Get(Expression<Func<DashboardSession, bool>> whereClause)
        {
            try
            {
                using (UBContext ubc = new UBContext())
                {
                    if (whereClause == null)
                        return ubc.DashboardSessions
                            .AsNoTracking()
                            .ToList();

                    return ubc.DashboardSessions
                        .AsNoTracking()
                        .Where(whereClause)
                        .ToList();

                }
            }
            catch
            {
                return new List<DashboardSession>();
            }
        }
    }
}