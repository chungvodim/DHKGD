using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Tearc.Utils.Common
{
    public static class ErrorHelper
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(ErrorHelper));
        public static EmailSpamChecker _EmailSpamChecker = new EmailSpamChecker();

        #region Public Methods

        #endregion
    }

    public class EmailSpamChecker
    {
        private ConfigurationManager _ConfigurationManager { get; }
        public EmailSpamChecker(IConfiguration configuration)
        {
            this._ConfigurationManager = new ConfigurationManager(configuration);
        }

        private static List<KeyValuePair<string, DateTime>> _Emails { get; set; }
        public static readonly object _LockObject = new object();

        public bool IsSpamMessage(string description, DateTime createdDate)
        {
            if (Monitor.TryEnter(_LockObject, new TimeSpan(0, 0, 10)))
            {
                try
                {
                    _Emails = _Emails.OrderByDescending(x => x.Value).ToList();

                    bool isSpam = true;

                    var recentSimilarEmails = _Emails.Where(x => x.Key == description).OrderByDescending(x => x.Value);

                    if (recentSimilarEmails == null || !recentSimilarEmails.Any())
                    {
                        isSpam = false;
                    }
                    else
                    {
                        var latestSimilarEmail = recentSimilarEmails.First();
                        if ((latestSimilarEmail.Value - DateTime.UtcNow).TotalMinutes > _ConfigurationManager.spamDuration)
                        {
                            isSpam = false;
                        }
                    }

                    if (!isSpam)
                    {
                        _Emails.Add(new KeyValuePair<string, DateTime>(description, createdDate));
                        if (_Emails.Count > _ConfigurationManager.maxStoredErrorDescriptions)
                        {
                            _Emails.RemoveAt(_Emails.Count - 1);
                        }
                    }

                    return isSpam;
                }
                finally
                {
                    Monitor.Exit(_LockObject);
                }
            }
            else
            {
                // failed to get lock: throw exceptions, log messages, get angry etc.
                throw new System.TimeoutException("failed to acquire the lock.");
            }
        }

        public EmailSpamChecker()
        {
            if(_Emails == null)
            {
                _Emails = new List<KeyValuePair<string, DateTime>>();
            }
        }
    }
}
