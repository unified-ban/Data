using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Unifiedban.Models;
using Unifiedban.Models.Translation;

namespace Unifiedban.Data
{
    public class TranslationService
    {
        #region " Language "
        public Language AddLanguage(Language language, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(language);
                    ubc.SaveChanges();
                    return language;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.LanguageService.AddLanguage",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.LanguageService.AddLanguage",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public Language UpdateLanguage(Language language, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                Language exists = ubc.Languages
                    .Where(x => x.LanguageId == language.LanguageId)
                    .FirstOrDefault();
                if (exists == null)
                    return null;

                try
                {
                    exists.Name = language.Name;
                    exists.UniversalCode = language.UniversalCode;
                    exists.Status = language.Status;

                    ubc.SaveChanges();
                    return language;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.LanguageService.UpdateLanguage",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.LanguageService.UpdateLanguage",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes RemoveLanguage(Language language, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                Language exists = ubc.Languages
                    .Where(x => x.LanguageId == language.LanguageId)
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
                        Function = "Unifiedban.Data.LanguageService.RemoveLanguage",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.LanguageService.RemoveLanguage",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<Language> GetLanguage(Expression<Func<Language, bool>> whereClause)
        {
            using (UBContext ubc = new UBContext())
            {
                if (whereClause == null)
                    return ubc.Languages
                        .AsNoTracking()
                        .ToList();

                return ubc.Languages
                    .AsNoTracking()
                    .Where(whereClause)
                    .ToList();

            }
        }
        #endregion

        #region " Key "
        public Key AddKey(Key key, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(key);
                    ubc.SaveChanges();
                    return key;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.LanguageService.AddKey",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.LanguageService.AddKey",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes RemoveKey(Key key, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                Key exists = ubc.TranslationKeys
                    .Where(x => x.KeyId == key.KeyId)
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
                        Function = "Unifiedban.Data.LanguageService.RemoveKey",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.LanguageService.RemoveKey",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<Key> GetKey(Expression<Func<Key, bool>> whereClause)
        {
            using (UBContext ubc = new UBContext())
            {
                if (whereClause == null)
                    return ubc.TranslationKeys
                        .AsNoTracking()
                        .ToList();

                return ubc.TranslationKeys
                    .AsNoTracking()
                    .Where(whereClause)
                    .ToList();

            }
        }
        #endregion

        #region " Entry "
        public Entry AddEntry(Entry entry, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                try
                {
                    ubc.Add(entry);
                    ubc.SaveChanges();
                    return entry;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.LanguageService.AddEntry",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.LanguageService.AddEntry",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public Entry UpdateEntry(Entry entry, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                Entry exists = ubc.TranslationEntries
                    .Where(x => x.KeyId == entry.KeyId)
                    .FirstOrDefault();
                if (exists == null)
                    return null;

                try
                {
                    exists.LanguageId = entry.LanguageId;
                    exists.Translation = entry.Translation;

                    ubc.SaveChanges();
                    return entry;
                }
                catch (Exception ex)
                {
                    Utils.Logging.AddLog(new SystemLog()
                    {
                        LoggerName = "Unifiedban",
                        Date = DateTime.Now,
                        Function = "Unifiedban.Data.LanguageService.UpdateEntry",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.LanguageService.UpdateEntry",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return null;
            }
        }
        public SystemLog.ErrorCodes RemoveEntry(Entry entry, int callerId)
        {
            using (UBContext ubc = new UBContext())
            {
                Entry exists = ubc.TranslationEntries
                    .Where(x => x.KeyId == entry.KeyId)
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
                        Function = "Unifiedban.Data.LanguageService.RemoveEntry",
                        Level = SystemLog.Levels.Warn,
                        Message = ex.Message,
                        UserId = callerId
                    });
                    if (ex.InnerException != null)
                        Utils.Logging.AddLog(new SystemLog()
                        {
                            LoggerName = "Unifiedban.Data",
                            Date = DateTime.Now,
                            Function = "Unifiedban.Data.LanguageService.RemoveEntry",
                            Level = SystemLog.Levels.Warn,
                            Message = ex.InnerException.Message,
                            UserId = callerId
                        });
                }
                return SystemLog.ErrorCodes.Error;
            }
        }
        public List<Entry> GetEntry(Expression<Func<Entry, bool>> whereClause)
        {
            using (UBContext ubc = new UBContext())
            {
                if (whereClause == null)
                    return ubc.TranslationEntries
                        .AsNoTracking()
                        .Include(x => x.Language)
                        .ToList();

                return ubc.TranslationEntries
                    .AsNoTracking()
                    .Where(whereClause)
                    .Include(x => x.Language)
                    .ToList();

            }
        }
        #endregion
    }
}
