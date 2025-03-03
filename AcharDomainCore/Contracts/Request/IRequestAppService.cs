using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Request
{
    public interface IRequestAppService
    {
        Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken);
        Task<bool> UpdateRequest(RequestUpDto requestUpDto, CancellationToken cancellationToken);
        Task<int> RequestCount(CancellationToken cancellationToken);
        Task<RequestGetDto> GetRequestById(int id, CancellationToken cancellationToken);
        Task<List<RequestGetDto?>> GetCustomerRequests(int customerId, CancellationToken cancellationToken);
        Task<List<RequestGetDto?>> GetRequests(CancellationToken cancellationToken);
        Task<List<RequestGetDto?>> GetRequestsByExpert(int expertId, CancellationToken cancellationToken);

        Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken);
        public Task<bool> ChangeRequestStatus(StatusRequestDto newStatus, CancellationToken cancellationToken);
        Task<bool> AcceptExpert(int id, int bidId, decimal bidPrice, CancellationToken cancellationToken);
        Task<bool> DoneRequest(int requestId, int bidId, CancellationToken cancellationToken);
        Task<bool> CancellRequest(int requestId, int bidId, CancellationToken cancellationToken);

    }
}
