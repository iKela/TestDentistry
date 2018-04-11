using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Entity
{
    public class User // Користувач, для входу в систему
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } //перевірка потрібна---
        public byte[] Photo { get; set; }
       

    }

    public class Policy
    {
        public int Id_Policy { get; set; }
        public string NamePolicy { get; set; }
        public bool Access { get; set; }
        public string DescriptionPolicy { get; set; }
        public ICollection<User> Users { get; set; }
    }
    public class MedCard
    {
        public int MedCardID { get; set; }
        public string dateOfCreatingMC { get; set; }
        public string NamePatient { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NumberPhone {get; set; }
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
        public  Doctor Doctor { get; set; }
        public string Epicris { get; set; } 
        public ICollection<Appoinment> Appoinments { get; set; }
    }
    public class Appoinment
    {
        public int AppoinmentId { get; set; }
        public string DateAppoinment { get; set; }
        public string Info { get; set; }
        public string Money { get; set; }
        public string Arrears { get; set; }
        #region Teeth 
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
        #endregion
        public MedCard MedCard { get; set; }
        public Doctor Doctor { get; set; }
    }
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string NameDoctor { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
    }


}
