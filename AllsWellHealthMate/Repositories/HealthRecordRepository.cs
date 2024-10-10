using AllsWellHealthMate.Data;
using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Repositories
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly HealthMateDbContext _context;

        public HealthRecordRepository(HealthMateDbContext context)
        {
            _context = context;
        }
        public IEnumerable<HealthRecord> GetAllHealthRecords()
        {
            return _context.HealthRecords.ToList();
        }

        public HealthRecord GetHealthRecordById(int id)
        {
            return _context.HealthRecords.SingleOrDefault(u => u.Id == id);
        }

        public HealthRecord GetHealthRecordByUserId(int userId)
        {
            return _context.HealthRecords.SingleOrDefault(u => u.UserId == userId);
        }

        public HealthRecord AddHealthRecordAsync(HealthRecord healthRecord)
        {
            _context.HealthRecords.Add(healthRecord); // Add user to the context
            _context.SaveChanges(); // Saving changes to generate the Id
            return healthRecord;
        }

        public void DeleteHealthRecord(int id)
        {
            var healthRecord = _context.HealthRecords.Find(id); // Find user by ID
            if (healthRecord != null)
            {
                _context.HealthRecords.Remove(healthRecord); // Remove user from the context
                _context.SaveChanges(); // Save changes to the database
            }
        }


        public void UpdateHealthRecord(HealthRecord healthRecord)
        {
            _context.HealthRecords.Update(healthRecord); // Add user to the context
            _context.SaveChanges(); // Saving changes to generate the Id        }
        }
    }
}
