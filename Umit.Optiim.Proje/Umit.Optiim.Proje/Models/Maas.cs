using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umit.Optiim.Proje.Models
{
    public class Maas
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string Departman { get; set; }
        public decimal Ucret { get; set; }
    }
}