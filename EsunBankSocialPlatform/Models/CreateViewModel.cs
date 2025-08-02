using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EsunBankSocialPlatform.Models
{
    public class CreateViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "標題")]
        [Required(ErrorMessage = "必填，不可空白")]
        public string Title { get; set; }

        [Display(Name = "內容")]
        [Required(ErrorMessage = "必填，不可空白")]
        public string Content { get; set; }
    }
}
