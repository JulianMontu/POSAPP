using POS.Infrastructure.Persistence.Contexts;
using POS.Infrastructure.Persistence.Interfaces;

namespace POS.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitsOfWork
    {
        private readonly PosContext _context;
        public ICategoryRepository Category { get; private set; }


        public UnitOfWork(PosContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
