namespace Domain.Dtos
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
    }
}