﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
//using Tearc.Utils.Common.AmazonLibrary;

namespace Tearc.Utils.Common
{
    public partial class EmailEngine
    {
        private ConfigurationManager _ConfigurationManager { get; }
        public EmailEngine(IConfiguration configuration)
        {
            this._ConfigurationManager = new ConfigurationManager(configuration);
        }
        /// <summary>
        /// Send welcome email to user about their acount to use ADAM system
        /// </summary>
        /// <param name="strToEmail">sender email</param>
        /// <param name="strBccEmail">bcc email; welcome@cargigi.com</param>
        /// <param name="strSubject">email subject</param>
        /// <param name="strBody">email content</param>
        /// <returns>result of sending</returns>
        public string MailMergeSending(string strToEmail, string strBccEmail, string strSubject, string strBody)
        {
            string strResult = string.Empty;
            MailMessage message = new MailMessage();
            MailAddress from = new MailAddress(_ConfigurationManager.smtpSendFrom);
            message.From = from;

            MailAddress to;
            string[] toEmails = strToEmail.Split(" ,;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string email in toEmails)
            {
                to = new MailAddress(email);
                message.To.Add(to);
            }

            MailAddress bcc;
            if (!string.IsNullOrEmpty(strBccEmail))
            {
                string[] bccEmails = strBccEmail.Split(" ,;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string email in bccEmails)
                {
                    bcc = new MailAddress(email);
                    message.Bcc.Add(bcc);
                }
            }

            message.Subject = strSubject;
            message.Body = strBody;
            message.IsBodyHtml = true;
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = _ConfigurationManager.smtpHost;
                smtp.Port = _ConfigurationManager.smtpPort;
                smtp.Credentials = new System.Net.NetworkCredential(_ConfigurationManager.smtpUsername, _ConfigurationManager.smtpPassword);
                smtp.EnableSsl = _ConfigurationManager.enableSSL;

                smtp.Send(message);
            }
            strResult = strSubject + " has been sent successfully.";
            return strResult;
        }


        #region Send Mail Asynchronously
        public void SendMailToDeveloper(MailMessage poMailMessage)
        {
            System.Threading.Thread oThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(SendEmailAsyncToDeveloper));
            oThread.Priority = System.Threading.ThreadPriority.BelowNormal;
            oThread.Start(poMailMessage);
        }

        static void SendEmailAsyncToDeveloper(object poMailMessage)
        {
            try
            {
                //AmazonSES.SendEmail((MailMessage)poMailMessage);
            }
            catch (Exception ex)
            {
                ErrorHelper.Logger.Error("Unable to SendEmailAsync. Error: " + ex.Message, ex);
            }
        }

        #endregion

    }
}
