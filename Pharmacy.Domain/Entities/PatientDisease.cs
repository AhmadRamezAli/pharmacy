using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class PatientDisease
    {
        public int Id { get; set; }
        public int Patient { get; set; }
        public int Disease { get; set; }

        public virtual Disease DiseaseNavigation { get; set; } = null!;
        public virtual Patient PatientNavigation { get; set; } = null!;
    }
}
