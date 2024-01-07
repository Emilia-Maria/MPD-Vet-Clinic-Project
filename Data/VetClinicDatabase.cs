using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_Clinic.Models;

namespace Vet_Clinic.Data
{
    public class VetClinicDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public VetClinicDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Appointment>().Wait();
            _database.CreateTableAsync<Doctor>().Wait();
            _database.CreateTableAsync<Invoice>().Wait();
            _database.CreateTableAsync<Owner>().Wait();
            _database.CreateTableAsync<Pet>().Wait();
            _database.CreateTableAsync<Treatment>().Wait();
        }
        public SQLiteAsyncConnection GetConnection()
        {
            return _database;
        }

        // CRUD for appointments' table
        public Task<List<Appointment>> GetAppointmentsAsync()
        {
            return _database.Table<Appointment>().ToListAsync();
        }
        public Task<Appointment> GetAppointmentsAsync(int id)
        {
            return _database.Table<Appointment>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppointmentAsync(Appointment alist)
        {
            if (alist.ID != 0)
            {
                return _database.UpdateAsync(alist);
            }
            else
            {
                return _database.InsertAsync(alist);
            }
        }
        public Task<int> DeleteAppointmentAsync(Appointment alist)
        {
            return _database.DeleteAsync(alist);
        }

        // CRUD for doctors' table
        public Task<List<Doctor>> GetDoctorsAsync()
        {
            return _database.Table<Doctor>().ToListAsync();
        }
        public Task<Doctor> GetDoctorsAsync(int id)
        {
            return _database.Table<Doctor>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveDoctorAsync(Doctor dlist)
        {
            if (dlist.ID != 0)
            {
                return _database.UpdateAsync(dlist);
            }
            else
            {
                return _database.InsertAsync(dlist);
            }
        }
        public Task<int> DeleteDoctorAsync(Doctor dlist)
        {
            return _database.DeleteAsync(dlist);
        }

        // CRUD for invoices' table
        public Task<List<Invoice>> GetInvoicesAsync()
        {
            return _database.Table<Invoice>().ToListAsync();
        }
        public Task<Invoice> GetInvoicesAsync(int id)
        {
            return _database.Table<Invoice>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveInvoiceAsync(Invoice ilist)
        {
            if (ilist.ID != 0)
            {
                return _database.UpdateAsync(ilist);
            }
            else
            {
                return _database.InsertAsync(ilist);
            }
        }
        public Task<int> DeleteInvoiceAsync(Invoice ilist)
        {
            return _database.DeleteAsync(ilist);
        }
        public Task<Invoice> GetInvoiceForAppointment(int appointmentID)
        {
            return Task.Run(async () =>
            {
                var invoices = await _database.QueryAsync<Invoice>(
                    "SELECT * FROM Invoice WHERE appointmentID = ?",
                    appointmentID);

                return invoices.FirstOrDefault();
            });
        }

        // CRUD for owners' table
        public Task<List<Owner>> GetOwnersAsync()
        {
            return _database.Table<Owner>().ToListAsync();
        }
        public Task<Owner> GetOwnersAsync(int id)
        {
            return _database.Table<Owner>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveOwnerAsync(Owner olist)
        {
            if (olist.ID != 0)
            {
                return _database.UpdateAsync(olist);
            }
            else
            {
                return _database.InsertAsync(olist);
            }
        }
        public Task<int> DeleteOwnerAsync(Owner olist)
        {
            return _database.DeleteAsync(olist);
        }

        // CRUD for pets' table
        public Task<List<Pet>> GetPetsAsync()
        {
            return _database.Table<Pet>().ToListAsync();
        }
        public Task<Pet> GetPetsAsync(int id)
        {
            return _database.Table<Pet>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SavePetAsync(Pet plist)
        {
            if (plist.ID != 0)
            {
                return _database.UpdateAsync(plist);
            }
            else
            {
                return _database.InsertAsync(plist);
            }
        }
        public Task<int> DeletePetAsync(Pet plist)
        {
            return _database.DeleteAsync(plist);
        }
        public Task<List<Pet>> GetPetsByOwnerAsync(int ownerID)
        {
            return _database.QueryAsync<Pet>(
                "SELECT * FROM Pet WHERE OwnerID = ?",
                ownerID);
        }

        // CRUD for treatments' table
        public Task<List<Treatment>> GetTreatmentsAsync()
        {
            return _database.Table<Treatment>().ToListAsync();
        }
        public Task<Treatment> GetTreatmentsAsync(int id)
        {
            return _database.Table<Treatment>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveTreatmentAsync(Treatment tlist)
        {
            if (tlist.ID != 0)
            {
                return _database.UpdateAsync(tlist);
            }
            else
            {
                return _database.InsertAsync(tlist);
            }
        }
        public Task<int> DeleteTreatmentAsync(Treatment tlist)
        {
            return _database.DeleteAsync(tlist);
        }
        public Task<Treatment> GetTreatmentForAppointment(int appointmentID)
        {
            return Task.Run(async () =>
            {
                var treatments = await _database.QueryAsync<Treatment>(
                    "SELECT * FROM Treatment WHERE appointmentID = ?",
                    appointmentID);

                return treatments.FirstOrDefault();
            });
        }
    }
}
