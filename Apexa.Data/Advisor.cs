using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Data
{
    public class Advisor
    {
        [Key]
        public int AdvisorId { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Sin { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? HealthStatus { get; set; }
    }
}
