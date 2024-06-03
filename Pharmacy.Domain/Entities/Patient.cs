using Pharmacy.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class Patient : Entity
    {
        public Patient()
        {
            PatientDiseases = new HashSet<PatientDisease>();
        }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PatientDisease> PatientDiseases { get; set; }
    }
}
