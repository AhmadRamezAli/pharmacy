using Pharmacy.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class Company : Entity
    {
        public Company()
        {
            Medicines = new HashSet<Medicine>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
