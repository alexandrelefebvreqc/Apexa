using System.ComponentModel.DataAnnotations;

namespace Apexa.Models
{
    public class AdvisorReadDto
    {
        public int AdvisorId { get; set; }
        public string? Name { get; set; }
        public string? Sin { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        public string? HealthStatus { get; set; }
    }
}