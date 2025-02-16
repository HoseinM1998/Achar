using AcharDomainCore.Contracts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Entites;

namespace AcharDomainService
{
    public class ExpertService :IExpertService
    {
        private readonly IExpertRepository _repository;
        public ExpertService(IExpertRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> UpdateExpert(ExpertDto expert, CancellationToken cancellationToken)
            => await _repository.UpdateExpert(expert, cancellationToken);

        public async Task<int> ExpertCount(CancellationToken cancellationToken)
            => await _repository.ExpertCount( cancellationToken);


        public async Task<ExpertProfDto?> GetExpertById(int id, CancellationToken cancellationToken)
            => await _repository.GetExpertById(id, cancellationToken);


        public async Task<decimal> GetBalanceExpertById(int expertId, CancellationToken cancellationToken)
            => await _repository.GetBalanceExpertById(expertId, cancellationToken);


        public async Task<List<ExpertProfDto>>? GetExperts(CancellationToken cancellationToken)
            => await _repository.GetExperts( cancellationToken);


        public async Task<bool> DeleteExpert(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteExpert(delete, cancellationToken);


        public async Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken)
            => await _repository.IActiveExpert(activeDto, cancellationToken);


        public async Task<List<ExpertProfDto?>> GetTopExpertsByScore(CancellationToken cancellationToken)
            => await _repository.GetTopExpertsByScore( cancellationToken);


        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
            => await _repository.UpdateBalance(id,balance, cancellationToken);

    }
}
