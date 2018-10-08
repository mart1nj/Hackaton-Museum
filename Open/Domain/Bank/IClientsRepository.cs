using Open.Core;
using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public interface IClientsRepository: IRepository<Client, ClientData> {
    }
}