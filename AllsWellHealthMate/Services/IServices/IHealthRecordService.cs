using System.Collections.Generic;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.DTOs;

namespace AllsWellHealthMate.Services
{
    public interface IHealthRecordService
    {
        IEnumerable<HealthRecord> GetAllHealthRecords();
        HealthRecord GetHealthRecordById(int id);
        HealthRecord GetHealthRecordByUserId(int userId);
        HealthRecord CreateHealthRecord(HealthRecordDTO healthRecordDTO);
        HealthRecord UpdateHealthRecord(HealthRecordDTO healthRecordDTO);
        void DeleteHealthRecord(int id);
    }
}