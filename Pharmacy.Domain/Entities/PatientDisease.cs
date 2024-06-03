using Pharmacy.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class PatientDisease : Entity
    {
        public int Patient { get; set; }
        public int Disease { get; set; }

        public virtual Disease DiseaseNavigation { get; set; } = null!;
        public virtual Patient PatientNavigation { get; set; } = null!;
    }
}
