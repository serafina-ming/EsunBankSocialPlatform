using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EsunBankSocialPlatform.Models
{
    public class LoginViewModel
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
    }
}
