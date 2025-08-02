using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EsunBankSocialPlatform.Models
{
	public class DisplayViewModel
	{
        public string PostId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
