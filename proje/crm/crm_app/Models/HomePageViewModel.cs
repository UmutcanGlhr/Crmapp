using Entities.Dtos;
using Entities.Models;

namespace crm_app.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Product>? Products { get; set; }
        public siteSettingsDto? siteSettings { get; set; }
        public Contact? Contact { get; set; }
        public IEnumerable<AppUser>? appUsers { get; set; }
    }
}