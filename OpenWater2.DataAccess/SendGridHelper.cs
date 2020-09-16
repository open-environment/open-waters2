using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using SendGrid;
using System.Net;
using System.Net.Mail;
using OpenWater2.DataAccess.Data.Repository.IRepository;

namespace OpwnWater2.DataAccess
{
    public class SendGridHelper
    {

        /// <summary>
        ///  Sends out an email from the application. Returns true if successful.
        /// </summary>
        public static bool SendGridEmail(string from, List<string> to, 
            List<string> cc, List<string> bcc, string subj, string body, 
            string smtpUser, string smtpUserPwd, ITOeSysLogRepository sysLogRepo)
        {
            try
            {
                //******************** CONSTRUCT EMAIL ********************************************
                // Create the email object first, then add the properties.
                var myMessage = new SendGridMessage();

                // Add message properties.
                myMessage.From = new EmailAddress(from);
                List<EmailAddress> emailAddresses = new List<EmailAddress>();
                foreach(string t in to)
                {
                    EmailAddress emailAddress = new EmailAddress(t);
                    emailAddresses.Add(emailAddress);
                }
                myMessage.AddTos(emailAddresses);
                if (cc != null)
                {
                    foreach (string cc1 in cc)
                        myMessage.AddCc(cc1);
                }
                if (bcc != null)
                {
                    foreach (string bcc1 in bcc)
                        myMessage.AddBcc(bcc1);
                }

                myMessage.Subject = subj;
                //myMessage.Html = "<p>" + body + "</p>";
                myMessage.HtmlContent = body;
                //*********************************************************************************


                //********************* SEND EMAIL ************************************************
                var credentials = new NetworkCredential(smtpUser, smtpUserPwd);
                // Create an Web transport for sending email.
                //TODO: Handle this
                //var transportWeb = new Web(credentials);

                // Send the email.
                //transportWeb.Deliver(myMessage);

                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    sysLogRepo.InsertT_OE_SYS_LOG("EMAIL ERR", ex.InnerException.ToString());
                else if (ex.Message != null)
                    sysLogRepo.InsertT_OE_SYS_LOG("EMAIL ERR", ex.Message.ToString());
                else
                    sysLogRepo.InsertT_OE_SYS_LOG("EMAIL ERR", "Unknown error");

                return false;

            }
        }


    }
}