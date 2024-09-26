namespace Entities.Models
{
    public class Company
    {
        public int companyID { get; set; }
        public String? companyName { get; set; } = String.Empty;
        public String? CompanyLogo { get; set; } = String.Empty;

        public String? userId {get;set;}

        public int? categoryId {get;set;}
        public Category? category {get;set;}
    }
}