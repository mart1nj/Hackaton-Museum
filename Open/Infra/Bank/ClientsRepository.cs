using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;

namespace Open.Infra.Bank
{
    public class ClientsRepository : Repository<Client, ClientData>, IClientsRepository
    {

        protected internal override async Task<ClientData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }

        public ClientsRepository(SentryDbContext c) : base(c?.Clients, c)
        {
        }

        protected internal override Client createObject(ClientData r)
        {
            return new Client(r);
        }

        protected internal override PaginatedList<Client> createList(
            List<ClientData> l, RepositoryPage p)
        {
            return new ClientsList(l, p);
        }
    }
}