using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading;
using SpamLib.Data;

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

        public string Login => _Login;
        public string Password => _Password;

        public MailService(string Login, string Password)
        {
            _Login = Login;
            _Password = Password;
        }

        struct SendMailInternalParameter
        {
            public string From;
            public string To;
        }

        private void SendMailInternal(object parameter)
        {
            var p = (SendMailInternalParameter) parameter;
            SendMail(p.From, p.To);
        }   

        public void SendMail(string From, string To)
        {
            try
            {
                using (var message = new MailMessage(From, To))
                {
                    message.Subject = _Subject;
                    message.Body = _Body;
                    message.IsBodyHtml = false;

                    using (var client = new SmtpClient(_ServerAddress, _Port))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(_Login, _Password);

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

        public void SendMails(string From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                SendMail(From, recipient.Email);
        }

        public void SendMailsParallel(string From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                ThreadPool.QueueUserWorkItem(p =>
                {
                    SendMail(From, recipient.Email);
                });

            //foreach (var recipient in To)
            //    ThreadPool.QueueUserWorkItem(
            //        SendMailInternal, 
            //        new SendMailInternalParameter
            //        {
            //            From = From,
            //            To = recipient.Email
            //        });
        }
    }
}
