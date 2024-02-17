using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Umit.Optiim.Api.Model
{
    public interface IPersonelService
    {

        IEnumerable<ValidationResult> PersonelVeMaasEkle(Personel personel, Maas maas);
        List<Personel> TumPersonelleriGetir();
        List<Personel> enSonEklenen();
        Personel PersonelGetir(int id);


    }
}

