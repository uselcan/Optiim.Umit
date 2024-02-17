using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Umit.Optiim.Api.Model;

namespace Umit.Optiim.Api.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly PersonelContext _dbContext; // Veritabanı bağlamı
        private readonly ILogger<PersonelService> _logger;

        public PersonelService(PersonelContext dbContext, ILogger<PersonelService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<ValidationResult> PersonelVeMaasEkle(Personel personel, Maas maas)
        {
            var validationResults = new List<ValidationResult>();

            // Personel ve Maas nesnelerinin doğrulama işlemleri yapılır
            if (personel == null)
            {
                validationResults.Add(new ValidationResult("Personel bilgileri boş olamaz."));
            }

            if (maas == null)
            {
                validationResults.Add(new ValidationResult("Maaş bilgileri boş olamaz."));
            }

            if (validationResults.Any())
            {
                return validationResults;
            }

            try
            {
                // Personel ve Maas nesneleri veritabanına eklenir
                _dbContext.Personel.Add(personel);
                _dbContext.SaveChanges();

                // PersonelId'yi Maas nesnesine ata ve veritabanına ekle
                maas.PersonelId = personel.Id;
                _dbContext.Maas.Add(maas);
                _dbContext.SaveChanges();

                // Başarı durumunda boş bir dizi döndürülür
                return Enumerable.Empty<ValidationResult>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kayıt sırasında bir hata oluştu: {ErrorMessage}", ex.Message);
                // Hata durumunda hata mesajı içeren bir dizi döndürülür
                return new ValidationResult[] { new ValidationResult($"Hata: {ex.Message}") };
            }
        }


        public List<Personel> TumPersonelleriGetir()
        {
        
            return _dbContext.Personel.Include(p => p.Detaylar).ToList();
        }

        public Personel PersonelGetir(int id)
        {
            // Veritabanından ilgili personeli bulma işlemi ve aynı zamanda detayları da yükleme
            return _dbContext.Personel.Include(p => p.Detaylar).FirstOrDefault(p => p.Id == id);
        }

        public List<Personel> enSonEklenen()
        {
            var enSonPersonel = _dbContext.Personel.OrderByDescending(p => p.Id).FirstOrDefault();
            return enSonPersonel != null ? new List<Personel> { enSonPersonel } : new List<Personel>();
        }
    }
}
