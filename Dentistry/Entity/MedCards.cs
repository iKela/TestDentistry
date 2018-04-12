namespace Dentistry.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedCards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedCards()
        {
            Appoinments = new HashSet<Appoinments>();
        }

        [Key]
        public int MedCardID { get; set; }

        public string dateOfCreatingMC { get; set; }

        public string NamePatient { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string NumberPhone { get; set; }

        public string Adress { get; set; }

        public string Diagnosis { get; set; }

        public string Complaint { get; set; }

        public string DoneDiseases { get; set; }

        public string CurrentDiseas { get; set; }

        public string SurvayData { get; set; }

        public string Bite { get; set; }

        public string MouthState { get; set; }

        public string XReyDate { get; set; }

        public string ColorVita { get; set; }

        public string DateOfLessons { get; set; }

        public string ControlDate { get; set; }

        public string SurvayPlan { get; set; }

        public string TreatmentPlan { get; set; }

        public string Epicris { get; set; }

        public int? Doctor_DoctorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appoinments> Appoinments { get; set; }

        public virtual Doctors Doctors { get; set; }
    }
}
