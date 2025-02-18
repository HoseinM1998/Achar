using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Expert
{
    public interface IExpertService
    {
        Task<bool> UpdateExpert(ExpertProfDto expert, CancellationToken cancellationToken);
        Task<int> ExpertCount(CancellationToken cancellationToken);
        Task<ExpertProfDto?> GetExpertById(int id, CancellationToken cancellationToken);
        Task<decimal> GetBalanceExpertById(int expertId, CancellationToken cancellationToken);
        Task<List<ExpertProfDto>>? GetExperts(CancellationToken cancellationToken);
        Task<bool> DeleteExpert(SoftDeleteDto delete, CancellationToken cancellationToken);
        Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken);
        Task<List<ExpertProfDto?>> GetTopExpertsByScore(CancellationToken cancellationToken);
        Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken);
    }
}
