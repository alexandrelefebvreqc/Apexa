using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Models
{
    public abstract class AdvisorManipulationDto
    {
        [Required (ErrorMessageResourceName = nameof(ModelsResources.RequiredField), ErrorMessageResourceType = typeof(ModelsResources))]
        [StringLength(255, ErrorMessageResourceName = nameof(ModelsResources.StringLength),ErrorMessageResourceType = typeof(ModelsResources))]
        public string? Name { get; set; }
        [StringLength(255, ErrorMessageResourceName = nameof(ModelsResources.StringLength), ErrorMessageResourceType = typeof(ModelsResources))]
        public string? Address { get; set; }
        [StringLength(8, MinimumLength = 8,  ErrorMessageResourceName = nameof(ModelsResources.ExactStringLength), ErrorMessageResourceType = typeof(ModelsResources))]
        [AllowNull]
        public string? Phone { get; set; }
    }
}