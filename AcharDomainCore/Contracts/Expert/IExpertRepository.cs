using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.ExpertDto;

namespace AcharDomainCore.Contracts.Expert
{
    public interface IExpertRepository
    {
        Task<int> CreateExpert(Entites.Expert expert, CancellationToken cancellationToken);
        Task<bool> UpdateExpert(ExpertDto expert, CancellationToken cancellationToken);
        Task<int> ExpertCount(CancellationToken cancellationToken);
        Task<ExpertProfDto?> GetExpertById(int id, CancellationToken cancellationToken);
        Task<decimal> GetBalanceExpertById(int expertId, CancellationToken cancellationToken);
        Task<List<ExpertProfDto>>? GetExperts(CancellationToken cancellationToken);
        Task<bool> DeleteExpert(SoftDeleteDto delete, CancellationToken cancellationToken);
        Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken);
        Task<List<Entites.Expert?>> GetTopExpertsByScore(CancellationToken cancellationToken);
        Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken);
    }
}
