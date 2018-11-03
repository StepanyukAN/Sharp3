namespace SpamLib
{
    public class Server
    {
        public int Port { get; set; }
        public string SMTP { get; set; }

        public override string ToString()
        {
            return $"{SMTP} : {Port}";
        }
    }
}
