
using System.Collections.Generic;
using System.Linq;
using AllsWellHealthMate.Data;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.Repositories;

namespace AllsWellHealthMate.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly HealthMateDbContext _context;

        public ProviderRepository(HealthMateDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Provider> GetAllProviders()
        {
            return _context.Providers.ToList();
        }
        public Provider GetProviderById(int id)
        {
            return _context.Providers.SingleOrDefault(u => u.Id == id);
        }
        public void AddProvider(Provider provider)
        {
            _context.Providers.Add(provider); // Add provider to the context
            _context.SaveChanges(); // Saving changes to generate the Id
        }

        public void DeleteProvider(int id)
        {
            var provider = _context.Providers.Find(id); // Find user by ID
            if (provider != null)
            {
                _context.Providers.Remove(provider); // Remove user from the context
                _context.SaveChanges(); // Save changes to the database
            }
        }

        

        
    }
}