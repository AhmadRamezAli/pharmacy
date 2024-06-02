using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class IngredientDAO
    {
        public IngredientDAO()
        {
            MedicienIngredients = new HashSet<MedicienIngredientDAO>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<MedicienIngredientDAO> MedicienIngredients { get; set; }
    }
}
