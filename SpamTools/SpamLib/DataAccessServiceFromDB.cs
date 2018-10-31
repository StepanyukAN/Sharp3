using System.Collections.ObjectModel;
using System.Linq;

namespace SpamLib
{
    public class DataAccessServiceFromDB : IDataAccessService
    {
        private SpamDatabaseDataContext _DatabaseContext;

        public DataAccessServiceFromDB()
        {
            _DatabaseContext = new SpamDatabaseDataContext();
        }

        public ObservableCollection<Recipient> GetRecipients()
        {
            return new ObservableCollection<Recipient>(_DatabaseContext.Recipient.ToArray());
        }

        public int CreateRecipient(Recipient recipient)
        {
            _DatabaseContext.Recipient.InsertOnSubmit(recipient);
            _DatabaseContext.SubmitChanges();
            return recipient.Id;
        }
    }
}
