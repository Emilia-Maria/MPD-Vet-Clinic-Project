using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_Clinic.Models
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [ForeignKey(typeof(Owner))]
        public int OwnerID { get; set; }
        [Ignore]
        public Owner SelectedOwner { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Owner AssociatedOwner { get; set; }
    }
}
