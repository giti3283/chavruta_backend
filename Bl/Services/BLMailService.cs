//בס"ד
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

namespace Bl.Services
{
    internal class BLMailService
    {

        public void Send(string userMail)
        {
            var consumerKey = "<CONSUMER_KEY>";
            var consumerSecret = "<CONSUMER_SECRET>";

            string url = "https://api.turbo-smtp.com/api/v2/mail/send";

            var mailData = new
            {
                from = "hello@your-company.com",
                to = userMail,
                subject = "New live training session",
                cc = "cc_user@example.com",
                bcc = "bcc_user@example.com",
                content = "Dear partner, we are delighted to invite you to an exclusive training session on UX Design. This session is designed to provide essential insights and practical strategies to enhance your skills.",
                html_content = "Dear partner, We are delighted to invite you to an exclusive training session on <strong>UX Design</strong>. This session is designed to provide essential insights and practical strategies to enhance your skills."
            }; // Mail Data setup.

           
            using (HttpClient httpClient = new HttpClient())
            {
                // JSON data seriaization
                var json = JsonSerializer.Serialize(mailData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Set authentication headers
                content.Headers.Add("consumerKey", consumerKey);
                content.Headers.Add("consumerSecret", consumerSecret);

                // Trigger POST request
                using (var response =  httpClient.PostAsync(url, content))
                {
                    if (response.IsCompletedSuccessfully)
                    {
                        var result =  response.Result.Content.ReadAsStringAsync();
                        Console.WriteLine("Response: " + result);
                    }
                    else
                    {
                        Console.WriteLine("Request error: " + response.Result.StatusCode);
                    }


                }
            }
}


   
    }
}