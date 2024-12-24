using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AccessRequest
    {
        public int Id { get; set; }
        public int PassId { get; set; }
        public string RequestedZone { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsApproved { get; set; }
        public string DenialReason { get; set; }
    }
}
