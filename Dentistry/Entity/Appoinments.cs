namespace Dentistry.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appoinments
    {
        [Key]
        public int AppoinmentId { get; set; }

        public string DateAppoinment { get; set; }

        public string Info { get; set; }

        public string Money { get; set; }

        public string Arrears { get; set; }

        public string tlt1 { get; set; }

        public string tlt2 { get; set; }

        public string tlt3 { get; set; }

        public string tlt4 { get; set; }

        public string tlt5 { get; set; }

        public string tlt6 { get; set; }

        public string tlt7 { get; set; }

        public string tlt8 { get; set; }

        public string trt1 { get; set; }

        public string trt2 { get; set; }

        public string trt3 { get; set; }

        public string trt4 { get; set; }

        public string trt5 { get; set; }

        public string trt6 { get; set; }

        public string trt7 { get; set; }

        public string trt8 { get; set; }

        public string brt1 { get; set; }

        public string brt2 { get; set; }

        public string brt3 { get; set; }

        public string brt4 { get; set; }

        public string brt5 { get; set; }

        public string brt6 { get; set; }

        public string brt7 { get; set; }

        public string brt8 { get; set; }

        public string blt1 { get; set; }

        public string blt2 { get; set; }

        public string blt3 { get; set; }

        public string blt4 { get; set; }

        public string blt5 { get; set; }

        public string blt6 { get; set; }

        public string blt7 { get; set; }

        public string blt8 { get; set; }

        public int? Doctor_DoctorId { get; set; }

        public int? MedCard_MedCardID { get; set; }

        public virtual Doctors Doctors { get; set; }

        public virtual MedCards MedCards { get; set; }
    }
}
