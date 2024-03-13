using Microsoft.Build.Framework;

namespace Again2.Areas.Admin.ViewModel
{
    public class SliderViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Offer { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
