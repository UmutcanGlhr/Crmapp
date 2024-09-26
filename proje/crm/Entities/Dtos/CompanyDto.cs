using Entities.Models;

namespace Entities.Dtos
{
    public record CompanyDto
    {
        public int companyID { get; init; }
        public String? companyName { get; init; } = String.Empty;
        public String? CompanyLogo { get; set; } = String.Empty;
        public String? userId { get; set; }

        public int? categoryId { get; init; }
        public Category? category { get; init; }
    }
}