using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class DiseaseMedicineDAO : DAO
    {
        public int Disease { get; set; }
        public int Medicine { get; set; }

        public virtual DiseaseDAO DiseaseNavigation { get; set; } = null!;
        public virtual MedicineDAO MedicineNavigation { get; set; } = null!;
    }
}
