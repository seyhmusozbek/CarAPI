using System;
using System.Threading.Tasks;
using Car.Core.Entities;
namespace Car.Core.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<CarDetails> cars { get;}
        Task Save();
    }
}
