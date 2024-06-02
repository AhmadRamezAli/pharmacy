using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class DiseaseMedicine
    {
        public int Id { get; set; }
        public int Disease { get; set; }
        public int Medicine { get; set; }

        public virtual Disease DiseaseNavigation { get; set; } = null!;
        public virtual Medicine MedicineNavigation { get; set; } = null!;
    }
}
