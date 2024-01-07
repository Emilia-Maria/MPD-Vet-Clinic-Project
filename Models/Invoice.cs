using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Clinic.Models
{
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int TotalAmount { get; set; }
        [ForeignKey(typeof(Appointment))]
        public int AppointmentID { get; set; }
    }
}
