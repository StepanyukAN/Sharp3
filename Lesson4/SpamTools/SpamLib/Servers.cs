using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public class Servers
    {
        public static readonly ObservableCollection<Server> Items =
            new ObservableCollection<Server>(new[]
            {
                new Server{ SMTP = "smtp.yandex.ru", Port = 25},
                new Server{ SMTP = "smtp.mail.ru", Port = 465},
                new Server{ SMTP = "smtp.gmail.com", Port = 465},
            });
    }
}
