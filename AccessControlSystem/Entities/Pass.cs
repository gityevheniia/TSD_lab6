namespace DAL.Entities
{
    public class Pass
    {
        public int Id { get; set; }
        public string PassNumber { get; set; }
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
    }
}
