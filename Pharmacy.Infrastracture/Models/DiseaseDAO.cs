using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class DiseaseDAO : DAO
    {
        public DiseaseDAO()
        {
            DiseaseMedicines = new HashSet<DiseaseMedicineDAO>();
            PatientDiseases = new HashSet<PatientDiseaseDAO>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<DiseaseMedicineDAO> DiseaseMedicines { get; set; }
        public virtual ICollection<PatientDiseaseDAO> PatientDiseases { get; set; }
    }
}
