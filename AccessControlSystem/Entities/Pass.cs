using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
