namespace Umit.Optiim.Api.Model
{
    public class RMaas
    {
        public string HataMesaj { get; set; }

        public bool Basarili
        {
            get
            {
                return HataMesaj == null;
            }
        }
        public List<Maas> Maas { get; set; }
    }
}
