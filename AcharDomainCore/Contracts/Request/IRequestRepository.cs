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
        Task<bool> UpdateRequest(RequestUpDto requestUpDto, CancellationToken cancellationToken);
        Task<int> RequestCount(CancellationToken cancellationToken);
        Task<RequestGetDto> GetRequestById(int id, CancellationToken cancellationToken);
        Task<List<RequestGetDto?>> GetRequests(CancellationToken cancellationToken);
        Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken);
        public Task<bool> ChangeRequestStatus(StatusRequestDto newStatus, CancellationToken cancellationToken);

    }
}
