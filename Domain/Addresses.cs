namespace Domain
{
    public class Addresses
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Addres { get; set; } //fix the naming
        public int PostCode { get; set; }
        public virtual Employees Employee { get; set; }
    }
}