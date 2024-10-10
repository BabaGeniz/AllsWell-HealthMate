using System.Collections.Generic;
using System.Linq;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.Data;

namespace AllsWellHealthMate.Repositories
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly HealthMateDbContext _context;

        public AllergyRepository(HealthMateDbContext context)
        {
            _context = context;
        }

        // Get all allergies
        public IEnumerable<Allergy> GetAllAllergies()
        {
            return _context.Allergies.ToList();
        }

        // Get allergy by ID
        public Allergy GetAllergyById(int id)
        {
            return _context.Allergies.FirstOrDefault(a => a.Id == id);
        }

        // Get allergies by HealthRecordId
        public IEnumerable<Allergy> GetAllergiesByHealthRecordId(int healthRecordId)
        {
            return _context.Allergies.Where(a => a.HealthRecordId == healthRecordId).ToList();
        }

        // Add a new allergy
        public Allergy AddAllergyAsync(Allergy allergy)
        {
            _context.Allergies.Add(allergy);
            _context.SaveChanges();
            return allergy;
        }
        public void UpdateAllergy(Allergy allergy)
        {
            _context.Allergies.Update(allergy);
            _context.SaveChanges();
        }

        // Delete an allergy by ID
        public void DeleteAllergy(int id)
        {
            var allergy = _context.Allergies.FirstOrDefault(a => a.Id == id);
            if (allergy != null)
            {
                _context.Allergies.Remove(allergy);
                _context.SaveChanges();
            }
        }
    }
}
