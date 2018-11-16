using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace SpamLib.Data
{
    public partial class SpamDatabase
    {
        static SpamDatabase() => System.Data.Entity.Database.SetInitializer(new SpamDatabaseInitializer());

        public void Test()
        {
            //Database.sq
        }
    }

    internal class SpamDatabaseInitializer :
        //DropCreateDatabaseIfModelChanges<SpamDatabase>
        DropCreateDatabaseAlways<SpamDatabase>
    {
        protected override void Seed(SpamDatabase context)
        {
            base.Seed(context);

            if (!context.Emails.Any())
            {
                context.Emails.AddOrUpdate(
                    new Email { Title = "Письмо 1", Body = "Текст письма 1" },
                    new Email { Title = "Письмо 2", Body = "Текст письма 2" },
                    new Email { Title = "Письмо 3", Body = "Текст письма 3" },
                    new Email { Title = "Письмо 4", Body = "Текст письма 4" }
                    );
                context.SaveChanges();
            }

            if (!context.Recipients.Any())
            {
                context.Recipients.AddOrUpdate(
                    new Recipient { Name = "Ivanov", Email = "ivanov@mail.ru" },
                    new Recipient { Name = "Petrov", Email = "petrov@mail.ru" },
                    new Recipient { Name = "Sidorov", Email = "sidorov@mail.ru" }
                    );
                context.SaveChanges();
            }

            if (!context.Senders.Any())
            {
                context.Senders.AddOrUpdate(
                    new Sender { Name = "Sender1", Email = "sender1@mail.ru", Login = "Sender1", Password = "pwd1" },
                    new Sender { Name = "Sender2", Email = "sender2@mail.ru", Login = "Sender2", Password = "pwd2" },
                    new Sender { Name = "Sender3", Email = "sender3@mail.ru", Login = "Sender3", Password = "pwd3" },
                    new Sender { Name = "Sender4", Email = "sender4@mail.ru", Login = "Sender4", Password = "pwd4" }
                    );
                context.SaveChanges();
            }

            if (!context.Servers.Any())
            {
                context.Servers.AddOrUpdate(
                    new Server { Name = "Mail", Address = "smtp.mail.ru", Port = 25, UseSSL = true },
                    new Server { Name = "Yandex", Address = "smtp.yandex.ru", Port = 25, UseSSL = true },
                    new Server { Name = "Gmail", Address = "smtp.gmail.com", Port = 25, UseSSL = true }
                    );
                context.SaveChanges();
            }

            if (!context.MailingLists.Any())
            {
                context.MailingLists.AddOrUpdate(
                    new MailingList
                    {
                        Name = "List 1",
                        Recipients = context.Recipients.ToArray()
                    });
                context.SaveChanges();
            }

            if (!context.ScheduleTasks.Any())
            {
                context.ScheduleTasks.AddOrUpdate(
                    new ScheduleTask
                    {
                        Name = "First task",
                        Emails = context.Emails.OrderBy(e => e.Id).Take(3).ToArray(),
                        Sender = context.Senders.First(),
                        Server = context.Servers.First(),
                        Time = DateTime.Now.Subtract(TimeSpan.FromMinutes(30))
                    },
                    new ScheduleTask
                    {
                        Name = "Second task",
                        Emails = context.Emails.OrderBy(e => e.Id).Take(3).ToArray(),
                        Sender = context.Senders.First(),
                        Server = context.Servers.First(),
                        Time = DateTime.Now.Add(TimeSpan.FromMinutes(30))
                    });
                context.SaveChanges();
            }
        }
    }
}
