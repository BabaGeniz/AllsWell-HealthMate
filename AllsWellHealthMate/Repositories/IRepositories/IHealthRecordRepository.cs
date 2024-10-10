using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Repositories
{
    public interface IHealthRecordRepository
    {
        IEnumerable<HealthRecord> GetAllHealthRecords();
        HealthRecord GetHealthRecordById(int id);
        HealthRecord GetHealthRecordByUserId(int userId);
        HealthRecord AddHealthRecordAsync(HealthRecord healthRecord);
        void UpdateHealthRecord(HealthRecord healthRecord);
        void DeleteHealthRecord(int id);
    }

}
