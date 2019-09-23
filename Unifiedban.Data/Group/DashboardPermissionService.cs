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
    public class DashboardPermissionService
    {
        public DashboardPermission Add(DashboardPermission dashboardPermission, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(dashboardPermission);
                    ubc.SaveChanges();
                    return dashboardPermission;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.DashboardPermissionService.Add",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.DashboardPermissionService.Add",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public DashboardPermission Update(DashboardPermission dashboardPermission, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                DashboardPermission exists = ubc.Group_DashboardPermissions
                    .Where(x => x.DashboardPermissionId == dashboardPermission.DashboardPermissionId)
                    .FirstOrDefault();
                if (exists == null)
                    return null;

                try
                {
                    exists.State = dashboardPermission.State;
                    exists.LastUpdateUtc = dashboardPermission.LastUpdateUtc;

                    ubc.SaveChanges();
                    return dashboardPermission;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.DashboardPermissionService.Update",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.DashboardPermissionService.Update",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes Remove(DashboardPermission dashboardPermission, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                DashboardPermission exists = ubc.Group_DashboardPermissions
                    .Where(x => x.DashboardPermissionId == dashboardPermission.DashboardPermissionId)
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
                        Function = "Unifiedban.Data.DashboardPermissionService.Remove",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.DashboardPermissionService.Remove",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<DashboardPermission> Get(Expression<Func<DashboardPermission, bool>> whereClause)
        {
            using (UBContext ubc = new UBContext())
            {
                if (whereClause == null)
                    return ubc.Group_DashboardPermissions
                        .AsNoTracking()
                        .ToList();

                return ubc.Group_DashboardPermissions
                    .AsNoTracking()
                    .Where(whereClause)
                    .ToList();

            }
        }
    }
}
