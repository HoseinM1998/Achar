using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Request
{
    public interface IRequestService
    {
        Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken);
        Task<bool> UpdateRequest(Entites.Request request, CancellationToken cancellationToken);
        Task<int> RequestCount(CancellationToken cancellationToken);
        Task<Entites.Request> GetRequestById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Request?>> GetRequests(CancellationToken cancellationToken);
        Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken);
        public Task<bool> ChangeRequestStatus(StatusRequestDto newStatus, CancellationToken cancellationToken);
    }
}
