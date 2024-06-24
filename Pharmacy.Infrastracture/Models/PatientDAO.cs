using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class PatientDAO : DAO
    {
        public PatientDAO()
        {
            PatientDiseases = new HashSet<PatientDiseaseDAO>();
        }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PatientDiseaseDAO> PatientDiseases { get; set; }
    }
}
