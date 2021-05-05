using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.WebUI.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private const string SendMailJetKey = "f4f5fe509651899904e16511e8855933";
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute( subject, htmlMessage, email);
        }

        private async Task Execute( string subject, string message, string email)
        {
            var client = new SmtpSender(() => new SmtpClient(host: "localhost")
            {
               EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25

                // DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                // PickupDirectoryLocation = @"C:\Demos"
            });

            //StringBuilder template = new();
            //template.AppendLine("Dear @Model.FirstName,");
            //template.AppendLine("<p> Thankks for Purchasing @Model.ProductName. @Model.message.</p>");
            //template.AppendLine("- Sam Demo ");


            Email.DefaultSender = client;
            //Email.DefaultRenderer = new RazorRenderer();

            var msg =  Email
                .From(emailAddress: "info@shopapp.com","ShopApp")
                .To(email)
                .Subject(subject)
                .Body(message)

                //.UsingTemplate(template.ToString(), new { FirstName = "Sam", ProductName = "Useless Thing",message = message })
                //.Body("Thanks For Buying our product")

           .SendAsync();
        }

        
    }
}
