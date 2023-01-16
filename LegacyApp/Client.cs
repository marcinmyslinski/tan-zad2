namespace LegacyApp
{
    public class Client
    {
        private int cid;

        public string Name { get; internal set; }
        public int ClientId { get; internal set; }
        public Client()
        {

        }

        public Client(int cid)
        {
            this.ClientId = cid;
        }
    }
}