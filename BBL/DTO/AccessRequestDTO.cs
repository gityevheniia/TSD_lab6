using System;

namespace BLL.DTO
{
    public class AccessRequestDTO
    {
        public int Id { get; set; }
        public int PassId { get; set; }
        public string RequestedZone { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public bool IsApproved { get; set; }
        public string? DenialReason { get; set; }
    }
}