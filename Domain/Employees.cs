namespace Domain
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Addresses> Addresses { get; set; } = new List<Addresses>();
        public ICollection<Positions> Positions { get; set; } = new List<Positions>();
        public DateTime DateOfSigning { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public bool IsActive { get; set; }
    }
}