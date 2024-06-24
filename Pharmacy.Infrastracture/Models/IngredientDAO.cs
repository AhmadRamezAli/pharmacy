using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class IngredientDAO : DAO
    {
        public IngredientDAO()
        {
            MedicienIngredients = new HashSet<MedicienIngredientDAO>();
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<MedicienIngredientDAO> MedicienIngredients { get; set; }
    }
}
