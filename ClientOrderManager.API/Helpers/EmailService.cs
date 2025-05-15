using ClientOrderManager.API.Models;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

namespace ClientOrderManager.API.Helpers
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendOrderCreatedEmail(Order order)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_config["EmailSettings:Sender"]));
            message.To.Add(MailboxAddress.Parse(_config["EmailSettings:Recipient"]));
            message.Subject = $"New Order Created: {order.Product}";
            message.Body = new TextPart("plain")
            {
                Text = $"A new order has been placed by {order.ClientName} for product {order.Product}."
            };

            using var client = new SmtpClient();
            client.Connect(_config["EmailSettings:SmtpHost"], 587, false);
            client.Authenticate(_config["EmailSettings:Username"], _config["EmailSettings:Password"]);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}