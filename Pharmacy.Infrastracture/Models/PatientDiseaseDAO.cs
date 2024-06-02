using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastracture.Models
{
    public partial class PatientDiseaseDAO
    {
        public int Id { get; set; }
        public int Patient { get; set; }
        public int Disease { get; set; }

        public virtual DiseaseDAO DiseaseNavigation { get; set; } = null!;
        public virtual PatientDAO PatientNavigation { get; set; } = null!;
    }
}
