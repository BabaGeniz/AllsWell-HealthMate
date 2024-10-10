using System.Collections.Generic;
using System.Linq;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.Data;

namespace AllsWellHealthMate.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly HealthMateDbContext _context;

        public PrescriptionRepository(HealthMateDbContext context)
        {
            _context = context;
        }

        // Get all prescriptions
        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return _context.Prescriptions.ToList();
        }

        // Get prescription by ID
        public Prescription GetPrescriptionById(int id)
        {
            return _context.Prescriptions.FirstOrDefault(p => p.Id == id);
        }

        // Get prescriptions by HealthRecordId
        public IEnumerable<Prescription> GetPrescriptionsByHealthRecordId(int healthRecordId)
        {
            return _context.Prescriptions.Where(p => p.HealthRecordId == healthRecordId).ToList();
        }

        // Add a new prescription
        public Prescription AddPrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
            return prescription;
        }
        public void UpdatePrescription(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            _context.SaveChanges();
        }

        // Delete a prescription by ID
        public void DeletePrescription(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.Id == id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
                _context.SaveChanges();
            }
        }
    }
}
