using Microsoft.AspNetCore.Identity;

namespace Entities.Dtos
{
    public record AdressDto
    {
        public int AddressID { get; init; }
        public String? CityName { get; init; }
        public String? DistrictName { get; init; }
        public String? AddressName { get; init; }
        public String? ZipCode { get; init; }

        public String? userId { get; set; }
        public IdentityUser? User { get; init; }
    }
}