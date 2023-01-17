namespace Domain.Dtos
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int? AddressId { get; set; }
        public int? PositionId { get; set; }
        public DateTime SigningDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual AddressDTO Address { get; set; }
        public virtual PositionDTO Position { get; set; }

    }
}