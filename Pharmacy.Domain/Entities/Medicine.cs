using Pharmacy.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class Medicine : Entity
    {
        public Medicine()
        {
            DiseaseMedicines = new HashSet<DiseaseMedicine>();
            MedicienIngredients = new HashSet<MedicienIngredient>();
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Category { get; set; }
        public decimal Dosage { get; set; }
        public int Company { get; set; }
        public string ScientificName { get; set; } = null!;

        public virtual MedicienIngredient CategoryNavigation { get; set; } = null!;
        public virtual Company CompanyNavigation { get; set; } = null!;
        public virtual ICollection<DiseaseMedicine> DiseaseMedicines { get; set; }
        public virtual ICollection<MedicienIngredient> MedicienIngredients { get; set; }
    }
}
