using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Expert
{
    public interface IExpertRepository
    {
        Task<int> CreateExpert(Entites.Expert expert, CancellationToken cancellationToken);
        Task<bool> UpdateExpert(Entites.Expert expert, CancellationToken cancellationToken);
        Task<Entites.Expert> GetExpertById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Expert>> GetExperts(CancellationToken cancellationToken);
        Task<bool> DeleteExpert(SoftDeleteDto delete, CancellationToken cancellationToken);
        Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken);

        Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken);
    }
}
