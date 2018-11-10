using System.Linq;

namespace SpamLib
{
    /// <summary>База данных</summary>
    public class DataBase
    {
        private readonly SpamDatabaseDataContext _Recipients = new SpamDatabaseDataContext();

        public IQueryable<Recipient> Recipients => _Recipients.Recipient;
    }
}
