using Pharmacy.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public class Category : Entity
    {
        public Category()
        {
            Medicines = new HashSet<Medicine>();
        }

        public string Name { get; set; } = null!;

        public ICollection<Medicine> Medicines { get; set; }
    }
}
