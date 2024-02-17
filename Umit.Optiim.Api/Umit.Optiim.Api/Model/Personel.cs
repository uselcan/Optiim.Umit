namespace Umit.Optiim.Api.Model
{
    public class Personel
    {
        public int Id { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string? Cinsiyet { get; set; }
        public ICollection<Maas>? Detaylar { get; set; }
    }
}
