using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApICallingResource
{
    public class Smtp : SmtpClient
    {
        public Smtp(int smtpPort, string smtpUrl, string smtpUsername, string smtpPassword)
        {
            Host = smtpUrl;
            Port = smtpPort;
            EnableSsl = true;
            Credentials = new NetworkCredential(smtpUsername, smtpPassword);
        }

        public bool Send(MailAddress to, MailAddress from, string subject, string body, out string resultMessage)
        {
            return Send(new List<MailAddress>() { to }, from, subject, body, null, out resultMessage);
        }

        public bool Send(List<MailAddress> to, MailAddress from, string subject, string body, MailAddressCollection ccMailAddresses, out string resultMessage)
        {
            return Send(to, from, subject, body, ccMailAddresses, null, out resultMessage);
        }

        public bool Send(List<MailAddress> to, MailAddress from, string subject, string body, MailAddressCollection ccMailAddresses, MailAddressCollection bccMailAddresses, out string resultMessage)
        {
            return Send(to, from, subject, body, ccMailAddresses, bccMailAddresses, null, out resultMessage);
        }

        public bool Send(List<MailAddress> to, MailAddress from, string subject, string body, MailAddressCollection ccMailAddresses, MailAddressCollection bccMailAddresses, List<Attachment> attachments, out string resultMessage)
        {
            bool result = false;
            resultMessage = string.Empty;
            try
            {
                if (to != null && to.Count > 0)
                {
                    if (from != null)
                    {
                        if (body != null)
                        {
                            MailMessage mailMessage = new MailMessage()
                            {
                                From = new MailAddress("Rahul <noreply@cvmus.com>"),
                                Subject = subject,
                                Body = body,
                                IsBodyHtml = true,
                                Priority = MailPriority.Normal
                            };

                            foreach (var toAddress in to)
                            {
                                mailMessage.To.Add(toAddress);
                            }

                            if (ccMailAddresses != null && ccMailAddresses.Count > 0)
                            {
                                foreach (var ccMailAddress in ccMailAddresses)
                                {
                                    mailMessage.CC.Add(ccMailAddress);
                                }
                            }

                            if (bccMailAddresses != null && bccMailAddresses.Count > 0)
                            {
                                foreach (var bccMailAddress in bccMailAddresses)
                                {
                                    mailMessage.Bcc.Add(bccMailAddress);
                                }
                            }

                            if (attachments != null && attachments.Count > 0)
                            {
                                foreach (var attachment in attachments)
                                {
                                    mailMessage.Attachments.Add(attachment);
                                }
                            }
                            Send(mailMessage);
                            result = true;
                        }
                        else
                        {
                            resultMessage = "Body data not available.";
                        }
                    }
                    else
                    {
                        resultMessage = "From email address not available.";
                    }
                }
                else
                {
                    resultMessage = "To email address not available.";
                }
            }
            catch (Exception ex)
            {
                resultMessage = ex.ToString();
            }
            return result;
        }
    }
}
