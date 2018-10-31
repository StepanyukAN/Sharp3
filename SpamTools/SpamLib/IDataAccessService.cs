using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();

        int CreateRecipient(Recipient recipient);
    }
}
