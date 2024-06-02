using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class Disease
    {
        public Disease()
        {
            DiseaseMedicines = new HashSet<DiseaseMedicine>();
            PatientDiseases = new HashSet<PatientDisease>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DiseaseMedicine> DiseaseMedicines { get; set; }
        public virtual ICollection<PatientDisease> PatientDiseases { get; set; }
    }
}
