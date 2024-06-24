using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class MedicineDAO : DAO
    {
        public MedicineDAO()
        {
            DiseaseMedicines = new HashSet<DiseaseMedicineDAO>();
            MedicienIngredients = new HashSet<MedicienIngredientDAO>();
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Category { get; set; }
        public decimal Dosage { get; set; }
        public int Company { get; set; }
        public string ScientificName { get; set; } = null!;

        public virtual CategoryDAO CategoryNavigation { get; set; } = null!;
        public virtual CompanyDAO CompanyNavigation { get; set; } = null!;
        public virtual ICollection<DiseaseMedicineDAO> DiseaseMedicines { get; set; }
        public virtual ICollection<MedicienIngredientDAO> MedicienIngredients { get; set; }
    }
}
