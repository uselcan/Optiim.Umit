namespace Umit.Optiim.Api.Model
{
    public class RPersonel
    {
        public string HataMesaj { get; set; }

        public bool Basarili
        {
            get
            {
                return HataMesaj == null;
            }
        }
        public List<Personel> Personel { get; set; }

    }
}
