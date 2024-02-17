using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Umit.Optiim.Api.Model;
using Umit.Optiim.Api.Services;

namespace Umit.Optiim.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

       

        [HttpGet]
        public IActionResult TumPersonelleriGetir()
        {
     
           

            var result = new RPersonel();
            result.HataMesaj = null;

            try
            {
               result.Personel = _personelService.TumPersonelleriGetir();
            }
            catch (Exception ex)
            {
                result.HataMesaj = "HATA : " + ex.Message;
            }



         
            return Ok(result);



        }


        [HttpGet("{id}")]
        public IActionResult PersonelGetir(int id)
        {
            try
            {
                var personeller = _personelService.PersonelGetir(id);

                if (personeller != null)
                {
        

                    return Ok(personeller); // 200 OK yanıtı ve personeller listesi döndürülür
                }
                else
                {
                    return NotFound(); // 404 Not Found yanıtı döndürülür
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Bir hata oluştu: " + ex.Message); // 400 Bad Request yanıtı ve hata mesajı döndürülür
            }
        }






        [HttpGet("enSonEklenen")]
        public IActionResult enSonEklenen()
        {



            var result = new RPersonel();
            result.HataMesaj = null;

            try
            {
                result.Personel = _personelService.enSonEklenen();
       
            }
            catch (Exception ex)
            {
                result.HataMesaj = "HATA : " + ex.Message;
            }




            return Ok(result);



        }
        [HttpPost("Kaydet")]
        public IActionResult Kaydet([FromBody] PersonelVeMaasViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Adi))
            {
                return BadRequest("Adı alanı boş bırakılamaz.");
            }

            if (string.IsNullOrEmpty(viewModel.Soyadi))
            {
                return BadRequest("Soyadı alanı boş bırakılamaz.");
            }
    
         


            // Personel ve Maaş nesnelerini oluştur
            var personel = new Personel
            {
                Adi = viewModel.Adi,
                Soyadi = viewModel.Soyadi,
                DogumTarihi = viewModel.DogumTarihi,
                Cinsiyet = viewModel.Cinsiyet
            };

            var maas = new Maas
            {
                Departman = viewModel.Departman,
                Ucret = viewModel.Ucret
            };

            // Personel ve Maaş nesnelerini kaydet
            var validationResults = _personelService.PersonelVeMaasEkle(personel, maas);
            if (validationResults != null && validationResults.Any())
            {
                return BadRequest(validationResults);
            }

            return Ok("Kayıt başarıyla tamamlandı.");
        }



    }
}
