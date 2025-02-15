using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;

namespace AcharDomainService
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        public RequestService(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken)
            => await _repository.CreateRequest(requestDto,cancellationToken);

        public async Task<bool> UpdateRequest(Request request, CancellationToken cancellationToken)
            => await _repository.UpdateRequest(request, cancellationToken);


        public async Task<int> RequestCount(CancellationToken cancellationToken)
            => await _repository.RequestCount(cancellationToken);


        public async Task<Request> GetRequestById(int id, CancellationToken cancellationToken)
            => await _repository.GetRequestById(id, cancellationToken);

        public async Task<List<Request?>> GetRequests(CancellationToken cancellationToken)
            => await _repository.GetRequests( cancellationToken);


        public async Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteRequest(delete, cancellationToken);


        public async Task<bool> ChangeRequestStatus(StatusRequestDto newStatus, CancellationToken cancellationToken)
            => await _repository.ChangeRequestStatus(newStatus, cancellationToken);

    }
}
