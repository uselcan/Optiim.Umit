using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Umit.Optiim.Api.Model
{
    public class PersonelContext :DbContext
    {
        public PersonelContext(DbContextOptions<PersonelContext> options) : base(options)
        {
        }
        public DbSet<Personel> Personel => Set<Personel>();
        public DbSet<Maas> Maas => Set<Maas>();
        public Personel GetEnSonEklenenPersonel()
        {
            return Personel.OrderByDescending(p => p.Id).FirstOrDefault();
        }
    }
}
