namespace Domain
{
    public class Positions
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public virtual Employees Employee { get; set; }

    }
}