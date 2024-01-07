using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Clinic.Models
{
    public class Treatment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        [ForeignKey(typeof(Appointment))]
        public int AppointmentID { get; set; }
    }
}
