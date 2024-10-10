using System.Collections.Generic;
using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Repositories
{
    public interface IProviderRepository
    {
        IEnumerable<Provider> GetAllProviders();
        Provider GetProviderById(int id);
        void AddProvider(Provider provider);
        void DeleteProvider(int id);
    }
}