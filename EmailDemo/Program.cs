using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sender = new SmtpSender(() => new SmtpClient(host: "localhost") 
            {
                EnableSsl =false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port=25

               // DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
               // PickupDirectoryLocation = @"C:\Demos"
            });

            StringBuilder template = new();
            template.AppendLine("Dear @Model.FirstName,");
            template.AppendLine("<p> Thankks for Purchasing @Model.ProductName. we Hope you enjoy it.</p>");
            template.AppendLine("- Sam Demo ");


            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            var email = await Email
                .From(emailAddress: "info@shopapp.com")
                .To("kemalsametasik@gmail.com", "Sam")
                .Subject("Thanks")
                .UsingTemplate(template.ToString(),new { FirstName="Sam",ProductName="Useless Thing"})
                //.Body("Thanks For Buying our product")
                .SendAsync();
        }
    }
}
