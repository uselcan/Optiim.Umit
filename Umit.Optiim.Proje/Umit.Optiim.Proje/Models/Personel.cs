using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umit.Optiim.Proje.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string String { get; set; }
        public ICollection<Maas> Maaslar { get; set; }
    }
}