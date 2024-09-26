using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public String? CategoryName { get; set; } = String.Empty;

         public ICollection<Company>? companies { get; set; }
    }
}