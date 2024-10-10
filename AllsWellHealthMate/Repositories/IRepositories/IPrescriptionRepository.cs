using System.Collections.Generic;
using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Repositories
{
    public interface IPrescriptionRepository
    {
        IEnumerable<Prescription> GetAllPrescriptions();
        Prescription GetPrescriptionById(int id);
        IEnumerable<Prescription> GetPrescriptionsByHealthRecordId(int healthRecordId);
        Prescription AddPrescriptionAsync(Prescription prescription);
        void UpdatePrescription(Prescription prescription);

        void DeletePrescription(int id);
    }
}
