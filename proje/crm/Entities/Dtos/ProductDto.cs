namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductID { get; init; }
        public String? ProductName { get; init; } = String.Empty;
        public String? price { get; init; }
        public String? Description { get; init; } = String.Empty;
        public String? descrp { get; init; } = String.Empty;
        public String? PaketSüresi { get; init; } = String.Empty;
        public String? DenemeSüresi { get; init; } = String.Empty;
    }
}