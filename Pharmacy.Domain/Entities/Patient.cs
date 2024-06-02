using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            PatientDiseases = new HashSet<PatientDisease>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PatientDisease> PatientDiseases { get; set; }
    }
}
