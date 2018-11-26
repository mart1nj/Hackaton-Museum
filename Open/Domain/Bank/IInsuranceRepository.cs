using System.Threading.Tasks;
using Open.Core;
using Open.Data.Bank;
namespace Open.Domain.Bank
{
    public interface IInsuranceRepository : IRepository<Insurance, InsuranceData> {
        Task<PaginatedList<Insurance>> LoadInsurancesForUser(string id);
    }
   
}
