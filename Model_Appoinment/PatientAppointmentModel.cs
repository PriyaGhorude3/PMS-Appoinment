using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Appoinment
{
   public  class PatientAppointmentModel
    {
        public int Id { get; set; }
        public int? Patientid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Physicianname { get; set; }
        public string AppoinmentType { get; set; }
        public string AppoinmentDate { get; set; }
        public double? AppoinmentTime { get; set; }
        public string Contactno { get; set; }
    }
}
