using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Models
{
    public class AdvisorCreationDto : AdvisorManipulationDto
    {
        [Required(ErrorMessageResourceName = nameof(ModelsResources.RequiredField), ErrorMessageResourceType = typeof(ModelsResources))]
        [StringLength(9, MinimumLength = 9, ErrorMessageResourceName = nameof(ModelsResources.ExactStringLength), ErrorMessageResourceType = typeof(ModelsResources))]
        public string Sin { get; set; }
    }
}