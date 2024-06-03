using Pharmacy.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class Disease : Entity
    {
        public Disease()
        {
            DiseaseMedicines = new HashSet<DiseaseMedicine>();
            PatientDiseases = new HashSet<PatientDisease>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<DiseaseMedicine> DiseaseMedicines { get; set; }
        public virtual ICollection<PatientDisease> PatientDiseases { get; set; }
    }
}
