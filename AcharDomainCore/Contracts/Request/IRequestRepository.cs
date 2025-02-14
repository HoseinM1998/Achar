using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.Request;

namespace AcharDomainCore.Contracts.Request
{
    public interface IRequestRepository
    {
        Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken);
        Task<bool> UpdateRequest(Entites.Request request, CancellationToken cancellationToken);
        Task<Entites.Request> GetRequestById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Request>> GetRequests(CancellationToken cancellationToken);
        Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken);
        public Task<bool> AcceptRequestStatus(AcceptExpertDto newStatus, CancellationToken cancellationToken);

    }
}
