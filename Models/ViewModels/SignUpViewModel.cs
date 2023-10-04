using NextLevel_Bootcamp_FinalWork.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace NextLevel_Bootcamp_FinalWork.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [EmailAddress]
        [Display(Name = "E-Posta")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="{0} alanı gerklidir.")]
        [StringLength(50, ErrorMessage = "{0} en fazla {1} karakter en az {2} karakter içermelidir.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girdiğiniz şifreler uyuşmuyor!")]
        [Display(Name = "Şifre Onaylama")]
        public string ConfirmPassword { get; set; }
    }
}
