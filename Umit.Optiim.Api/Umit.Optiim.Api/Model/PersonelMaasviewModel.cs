using System.ComponentModel.DataAnnotations;

namespace Umit.Optiim.Api.Model
{
    public class PersonelVeMaasViewModel
    {
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyadı alanı gereklidir.")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "Doğum tarihi alanı gereklidir.")]
        public DateTime DogumTarihi { get; set; }

        [Required(ErrorMessage = "Cinsiyet alanı gereklidir.")]
        public string Cinsiyet { get; set; }

        [Required(ErrorMessage = "Departman alanı gereklidir.")]
        public string Departman { get; set; }

        [Required(ErrorMessage = "Ücret alanı gereklidir.")]
        [Range(0, double.MaxValue, ErrorMessage = "Ücret alanı pozitif bir değer olmalıdır.")]
        public decimal Ucret { get; set; }

        public int DepartmanId { get; set; }
    }

}
