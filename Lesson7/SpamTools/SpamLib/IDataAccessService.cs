using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SpamLib.Data;

namespace SpamLib
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();
        Task<ObservableCollection<Recipient>> GetRecipientsAsync();

        int CreateRecipient(Recipient recipient);

        Task<ObservableCollection<ScheduleTask>> GetScheduleTask();

        Task<ObservableCollection<Email>> GetEmailsAsync();

        Task<bool> AddNewEmailAsync(Email email);
        Task<bool> RemoveEmailAsync(Email email);
    }

    public class DataAccessServiceFromDB : IDataAccessService
    {
        public ObservableCollection<Recipient> GetRecipients()
        {
            using (var db = new SpamDatabase())
                return new ObservableCollection<Recipient>(db.Recipients.ToArray());
        }

        public async Task<ObservableCollection<Recipient>> GetRecipientsAsync()
        {
            using (var db = new SpamDatabase())
                return new ObservableCollection<Recipient>(await db.Recipients.ToArrayAsync());
        }

        public int CreateRecipient(Recipient recipient)
        {
            using (var db = new SpamDatabase())
            {
                db.Recipients.Add(recipient);
                if (db.SaveChanges() > 0)
                    return recipient.Id;
            }
            return 0;
        }

        public async Task<int> CreateRecipientAsync(Recipient recipient)
        {
            using (var db = new SpamDatabase())
            {
                db.Recipients.Add(recipient);
                if (await db.SaveChangesAsync().ConfigureAwait(false) > 0)
                    return recipient.Id;
            }
            return 0;
        }

        public async Task<ObservableCollection<ScheduleTask>> GetScheduleTask()
        {
            using (var db = new SpamDatabase())
                return new ObservableCollection<ScheduleTask>(await db.ScheduleTasks
                        .Include(task => task.Emails)
                        .Include(task => task.MailingList)
                        .Include(task => task.Sender)
                        .Include(task => task.Server)
                        .Include(task => task.MailingList.Recipients)
                        .ToArrayAsync().ConfigureAwait(false));
        }

        public async Task<ObservableCollection<Email>> GetEmailsAsync()
        {
            using (var db = new SpamDatabase())
                return new ObservableCollection<Email>(await db.Emails.ToArrayAsync());
        }

        public async Task<bool> AddNewEmailAsync(Email email)
        {
            using (var db = new SpamDatabase())
            {
                db.Emails.Add(email);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> RemoveEmailAsync(Email email)
        {
            using (var db = new SpamDatabase())
            {
                db.Emails.Attach(email);
                db.Emails.Remove(email);
                return await db.SaveChangesAsync() > 0;
            }
        }
    }
}
