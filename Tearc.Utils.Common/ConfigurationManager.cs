using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Tearc.Utils.Common
{
    public class ConfigurationManager
    {
        public ConfigurationManager(IConfiguration configuration)
        {
            if(Configuration == null)
            {
                Configuration = configuration;
            }
        }
        public static IConfiguration Configuration { get; set; }
        public readonly string errFromEmail = Configuration["errFromEmail"];
        public readonly string errToEmail = Configuration["errToEmail"];
        public readonly string smtpSendFrom = Configuration["smtpSendFrom"];
        public readonly string smtpHost = Configuration["AWS.smtpHost"];
        public readonly int smtpPort = Convert.ToInt32(Configuration["AWS.smtpPort"]);
        public readonly string smtpUsername = Configuration["AWS.smtpUsername"];
        public readonly string smtpPassword = Configuration["AWS.smtpPassword"];
        public readonly bool enableSSL = Convert.ToBoolean(Configuration["enableSSL"]);
        public readonly bool isTestMode = Convert.ToBoolean(Configuration["isTestMode"]);
        public readonly string testerEmail = Configuration["testerEmail"];
        public readonly string supportEmail = Configuration["supportEmail"];
        public readonly short maxFileCount = Convert.ToInt16(Configuration["maxFileCount"]);
        public readonly string EMAIL_IMAGE_ATTATCHMENT_URL = Configuration["EMAIL_IMAGE_ATTATCHMENT_URL"];
        public readonly short balanceRefreshFrequency = Convert.ToInt16(Configuration["balanceRefreshFrequency"]);
        public readonly bool turnOnValidateAntiForgery = Convert.ToBoolean(Configuration["turnOnValidateAntiForgery"]);
        public readonly bool enableGoogleTagManager = Convert.ToBoolean(Configuration["enableGoogleTagManager"]);
        public readonly string email2dehandsSupport = Configuration["2dehandsSupport"];
        public readonly string emaild2ememainSupport = Configuration["2ememainSupport"];
        public readonly string adminCompanyID = Configuration["adminCompanyID"] ?? "1";
        public readonly string validImageExtension = Configuration["validImageExtension"] ?? "jpeg,jpg,gif,png";
        public const short expirationMinutes = 24 * 60;
        public readonly bool searchOnly1Page = Convert.ToBoolean(Configuration["searchOnly1Page"]);
        public readonly bool disableErrorEmail = Convert.ToBoolean(Configuration["disableErrorEmail"]);
        public readonly bool disableInlineTranslation = Convert.ToBoolean(Configuration["disableInlineTranslation"]);
        public readonly bool useS3TempFolder = Convert.ToBoolean(Configuration["useS3TempFolder"]);
        public readonly string statisticUpdatedTime = Configuration["statisticUpdatedTime"] ?? "16:00";
        public readonly int listingPastDays = Convert.ToInt32(Configuration["listingPastDays"] ?? "2");
        public readonly int spamDuration = Convert.ToInt32(Configuration["spamDuration"] ?? "10");
        public readonly int maxStoredErrorDescriptions = Convert.ToInt32(Configuration["maxStoredErrorDescriptions"] ?? "100");
        public readonly string environment = Configuration["environment"];
        public const string BE_LongDateFormat = "HH:mm dd MMMM yyyy";
        public const string BE_ShortDateFormat = "dd MMMM yyyy";
        public const string Morris_ShortDateFormat = "yyyy-MM-dd";
        public readonly int ServerUtcOffset = Convert.ToInt32(TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).TotalHours);
    }
}
