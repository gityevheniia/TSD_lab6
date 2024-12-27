using System;

namespace BLL.DTO
{
    public class PassDTO
    {
        public int Id { get; set; }
        public string PassNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
    }
}