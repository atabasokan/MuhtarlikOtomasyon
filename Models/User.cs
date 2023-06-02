using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace MuhtarlıkOtomasyon.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "TC No")]
        [Required(ErrorMessage = "TC No doldurulmalıdır")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçerli bir TC No giriniz")]
        public string Tc_no { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad doldurulmalıdır")]
        public string Ad { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad doldurulmalıdır")]
        public string Soyad { get; set; }

        [Display(Name = "Anne Adı")]
        [Required(ErrorMessage = "Anne Adı doldurulmalıdır")]
        public string Anne_Adı { get; set; }

        [Display(Name = "Baba Adı")]
        [Required(ErrorMessage = "Baba Adı doldurulmalıdır")]
        public string Baba_Adı { get; set; }

        [Display(Name = "Doğum Yeri")]
        [Required(ErrorMessage = "Doğum Yeri doldurulmalıdır")]
        public string Doğum_Yeri { get; set; }
        
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Adres doldurulmalıdır")]
        public string Adres { get; set; }

        [Display(Name = "Mahalle")]
        [Required(ErrorMessage = "Adres doldurulmalıdır")]
        public string Mahalle { get; set; }

        [Display(Name = "Kan Grubu")]
        [Required(ErrorMessage = "Kan Grubu doldurulmalıdır")]
        public string Kan_Grup { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre doldurulmalıdır")]
        [DataType(DataType.Password)]
        public string Şifre { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Doğum_Tarihi { get; set; }
    }
}
