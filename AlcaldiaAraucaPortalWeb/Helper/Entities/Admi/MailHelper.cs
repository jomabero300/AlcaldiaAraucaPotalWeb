﻿using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Admi
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response SendMail(string to, string subject, string body, MemoryStream attachment = null)
        {
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            int port = int.Parse(_configuration["Mail:Port"]);
            var password = _configuration["Mail:Password"];

            try
            {
                // Smtp client
                var client = new SmtpClient
                {
                    Port = port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = smtp,
                    EnableSsl = false,
                    Credentials = new NetworkCredential(from, password)
                };
                using (client)
                {
                    var mail = new MailMessage
                    {
                        To = { new MailAddress(to) },
                        From = new MailAddress(from, "Arauca activa"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                    if (attachment != null)
                    {
                        mail.Attachments.Add(new Attachment(attachment, "Araucactiva.pdf", MediaTypeNames.Application.Pdf));
                    }

                    client.Send(mail);
                    mail.Dispose();
                }

                return new Response { Succeeded = true };
            }
            catch (Exception ex)
            {
                return new Response { Succeeded = false, Message = ex.Message };
            }
        }
    }
}
