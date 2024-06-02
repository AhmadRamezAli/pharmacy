using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class MedicienIngredientDAO
    {
        public int Id { get; set; }
        public int Medicine { get; set; }
        public int Ingredient { get; set; }
        public decimal Ratio { get; set; }

        public virtual IngredientDAO IngredientNavigation { get; set; } = null!;
        public virtual MedicineDAO MedicineNavigation { get; set; } = null!;
    }
}
