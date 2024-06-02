using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class CompanyDAO :DAO
    {
        public CompanyDAO()
        {
            Medicines = new HashSet<MedicineDAO>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<MedicineDAO> Medicines { get; set; }
    }
}
