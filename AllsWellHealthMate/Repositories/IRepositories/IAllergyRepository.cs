using System.Collections.Generic;
using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Repositories
{
    public interface IAllergyRepository
    {
        IEnumerable<Allergy> GetAllAllergies();
        Allergy GetAllergyById(int id);
        IEnumerable<Allergy> GetAllergiesByHealthRecordId(int healthRecordId);
        Allergy AddAllergyAsync(Allergy allergy);
        void UpdateAllergy(Allergy allergy);
        void DeleteAllergy(int id);
    }
}