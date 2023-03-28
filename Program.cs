using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ApICallingResource
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendMailViaAmazonSes();
          //  SendMail("This is sample mail");
            //CallLeadFeedApi();
        }


        public static void CallLeadFeedApi()
        {
            string url = "https://staging-api.centerforvein.com/lead/api/LeadFeed/LeadFeedAdd";
            string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkZEQzAxMDM3MzEzQ0VDQTU1M0M3NjVFRkZCMEJCNTQ4Mjg2ODg1QkNSUzI1NiIsIng1dCI6Il9jQVFOekU4N0tWVHgyWHYtd3UxU0Nob2hidyIsInR5cCI6ImF0K2p3dCJ9.eyJpc3MiOiJodHRwczovL3N0YWdpbmctYXBpLmNlbnRlcmZvcnZlaW4uY29tL2lkZW50aXR5IiwibmJmIjoxNjU0MDEwMzAzLCJpYXQiOjE2NTQwMTAzMDMsImV4cCI6MTY1NDAyNDcwMywiYXVkIjpbImxlYWR0cmFjayIsImh0dHBzOi8vc3RhZ2luZy1hcGkuY2VudGVyZm9ydmVpbi5jb20vaWRlbnRpdHkvcmVzb3VyY2VzIl0sInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJsdC51c2VyLnJlYWQiXSwiYW1yIjpbIm1mYSJdLCJjbGllbnRfaWQiOiI0OTBmMDI1MDNiODQ0NjQwYTU4OWIzYWNlZGIyZDMxYSIsInN1YiI6IkNGRUU0MTQwLUMyRDQtNENDNC04ODdBLUMyNEVCQzk2MzE0RiIsImF1dGhfdGltZSI6MTY1NDAxMDMwMSwiaWRwIjoibG9jYWwiLCJpZCI6IjE5IiwiZW50ZXJwcmlzZWd1aWQiOiI2Rjk2MTlGRi04Qjg2LUQwMTEtQjQyRC0wMEMwNEZDOTY0RkYiLCJlbnRlcnByaXNlaWQiOiIyIiwibmFtZSI6IlJhaHVsIFRhbmsiLCJyb2xlIjoiVXNlciIsInNpZCI6IkJDM0NCMEUzOTdEOTVDQzYzNDZENEM1MTg5Rjg2QjI1IiwianRpIjoiNzJBMzE0QTU1MzEwQTUzNUNDOUMxMjg1RUZDQThGOTQifQ.RKyMgR7eIVzBUN6PnaB6iveqblk2ouDy36kREzj3Pp6MGHV01yVDdBwqF4A8sryfvHVlyUnJQ6_MzYWZHVwesFO3v_WiGvJygM8wRxn5FtsuImIW7pFtNu8eJcOXtW5tBM162Rg02KvdApTYhwsGgdPMnYtRQRa9L8nueIpekVuImhaOyLJTstJC_NTvnc81FZ8ls38L0ZloY_yadmT3fns0PLZ6985uJwexVLY9cjHZ-7Ldu-vSi4YujSbiKyXkemknCJ2b7458fmzUQ_jypAlKFy1tAJpNLdaHuwd4G0ay8_Wybk4p1L1pW5hvov94t5hUvpyFp8Xv5yt4C8fR3Q";
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(url);
            //byte[] cred = UTF8Encoding.UTF8.GetBytes("username:password");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var data = JsonConvert.SerializeObject(new LeadFeedRequest()
            {
                CampaignId = "guWRIUeoHnyqFbA8mkAH3F8UnrQC3l6SReuOzrZAgus=",
                Language = "English",
                FirstName = "Rahul",
                MiddleName = "k",
                LastName = "Tank",
                Email1 = "r.tank@abjima.com",
                Custom1 = "123456789"
            });

            System.Net.Http.HttpContent content = new StringContent(data, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(url, content).Result;
            string description = string.Empty;
            if (messge.IsSuccessStatusCode)
            {
                string result = messge.Content.ReadAsStringAsync().Result;
                description = result;
            }
        }


        public static void SendMailViaAmazonSes()
        {
            string host = "email-smtp.us-east-1.amazonaws.com";
            int port = 587;
            string userName = "AKIARXBNWPNBCBT4S4OZ";
            string password = "BEirMui5qcPohSPt6jbI/nLYeMGhAxicSKbIKB/7OUKT";
            string subject = "Test email";

            Smtp smtp = new Smtp(port, host, userName, password);
            var fromAddress = new MailAddress("noreply@cvmus.com", "RahulTank");
            var toAddress = new MailAddress("rahul.tank@abjima.com");
            string resultMessage = "";
            try
            {
                smtp.Send(toAddress, fromAddress, subject, "Hello CVM Test Email", out resultMessage);
            }
            catch (Exception ex)
            {
            }

        }
        public static void SendMail(string execption)
        {
            string FROM = "noreply@centerforvein.com";

            string FROMNAME = "Rahul Tank";
            string Host = "email-smtp.us-east-1.amazonaws.com";
            int Port = 587;
            string UserName = "AKIAJGONKYHQQL7BB2EA";
            string Password = "AsL1UgqcL19aBzqKPfgChqb+AuMM3B4qhazJvS++XWIu";


            string TO = "rahul.tank@abjima.com";



            string SUBJECT =
            "Amazon SES test (SMTP interface accessed using C#)";



            MailMessage message = new MailMessage();
            // message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = execption;
            // Comment or delete the next line if you are not using a configuration set
            // message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);



            using (var client = new System.Net.Mail.SmtpClient(Host, Port))
            {
                // Pass SMTP credentials
                client.Credentials =
                new NetworkCredential(UserName, Password);



                // Enable SSL encryption
                client.EnableSsl = true;



                // Try to send the message. Show status in console.
                try
                {
                    // Console.WriteLine("Attempting to send email...");
                    client.Send(message);
                    //Console.WriteLine("Email sent!");
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("The email was not sent.");
                    //Console.WriteLine("Error message: " + ex.Message);
                }
            }
        }
    }

    public class LeadFeedRequest
    {
        public string CampaignId { get; set; }
        public string Language { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email1 { get; set; }
        public string Custom1 { get; set; }

    }
}
