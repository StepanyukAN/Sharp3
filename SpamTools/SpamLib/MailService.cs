using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    /// <summary>Рассылка почты</summary>
    public class MailService
    {
        private string _Login;
        private string _Password;

        private string _ServerAddress = "smtp.yandex.ru";
        private int _Port = 25;

        private string _Body;
        private string _Subject;

        public MailService(string Login, string Password)
        {
            (_Login, _Password) = (Login, Password);
        }

        public void SendMail(string Mail, string Name)
        {
            try
            {
                using (var message = new MailMessage(Name, Mail)
                {
                    Subject = _Subject,
                    Body = _Body,
                    IsBodyHtml = false
                })
                {
                    using (var client = new SmtpClient(_ServerAddress, _Port)
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(_Login, _Password)
                    })
                    {
                          client.Send(message);
                    } 
                }
            }
            catch (Exception error)
            {
                Trace.WriteLine(error.ToString());
                throw new InvalidOperationException("Ошибка отправки почты", error);
            }
        }
    }
}
