using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Expert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Entites;

namespace AcharDomainAppService
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _service;
        public ExpertAppService(IExpertService service)
        {
            _service = service;
        }

        public async Task<bool> UpdateExpert(ExpertDto expert, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateExpert(expert, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateExpert: {ex.Message}");
            }
        }

        public async Task<int> ExpertCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.ExpertCount( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ExpertCount: {ex.Message}");
            }
        }

        public async Task<ExpertProfDto?> GetExpertById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetExpertById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetExpertById: {ex.Message}");
            }
        }

        public async Task<decimal> GetBalanceExpertById(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetBalanceExpertById(expertId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetBalanceExpertById: {ex.Message}");
            }
        }

        public async Task<List<ExpertProfDto>>? GetExperts(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetExperts(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetExperts: {ex.Message}");
            }
        }

        public async Task<bool> DeleteExpert(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteExpert(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteExpert: {ex.Message}");
            }
        }

        public async Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.IActiveExpert(activeDto, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error IActiveExpert: {ex.Message}");
            }
        }

        public async Task<List<ExpertProfDto?>> GetTopExpertsByScore(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetTopExpertsByScore( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetTopExpertsByScore: {ex.Message}");
            }
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateBalance(id,balance, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateBalance: {ex.Message}");
            }
        }
    }
}
