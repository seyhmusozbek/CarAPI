using System;
using System.Threading.Tasks;
using Car.Core.Contracts;
using Car.Core.Entities;
using Car.Infrastructure.Database;

namespace Car.Infrastructure.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarContext _context;
        private IGenericRepository<CarDetails> _cars;


        public UnitOfWork(CarContext context)
        {
            _context = context;
        }

        public IGenericRepository<CarDetails> cars => _cars ??= new GenericRepository<CarDetails>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
