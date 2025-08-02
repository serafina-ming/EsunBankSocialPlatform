using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EsunBankSocialPlatform.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "手機號碼")]
        [Required(ErrorMessage = "必填，不可空白")]
        [Phone(ErrorMessage = "手機格式有誤")]
        public string PhoneNumber { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "必填，不可空白")]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "使用者名稱")]
        [Required(ErrorMessage = "必填，不可空白")]
        public string UserName { get; set; }

        [Display(Name = "電子郵件")]
        [Required(ErrorMessage = "必填，不可空白")]
        [EmailAddress(ErrorMessage = "Email格式有誤")]
        public string Email { get; set; }

        [Display(Name = "自我介紹")]
        [Required(ErrorMessage = "必填，不可空白")]
        public string Biography { get; set; }
    }
}
