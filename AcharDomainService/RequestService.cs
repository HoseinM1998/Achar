using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;
using HomeService.Domain.Core.Enums;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        private readonly ILogger<RequestService> _logger;

        public RequestService(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken)
            => await _repository.CreateRequest(requestDto,cancellationToken);

        public async Task<bool> UpdateRequest(RequestUpDto request, CancellationToken cancellationToken)
            => await _repository.UpdateRequest(request, cancellationToken);


        public async Task<int> RequestCount(CancellationToken cancellationToken)
            => await _repository.RequestCount(cancellationToken);


        public async Task<RequestGetDto> GetRequestById(int id, CancellationToken cancellationToken)
            => await _repository.GetRequestById(id, cancellationToken);

        public async Task<List<RequestGetDto?>> GetRequests(CancellationToken cancellationToken)
            => await _repository.GetRequests( cancellationToken);


        public async Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteRequest(delete, cancellationToken);


        public async Task<bool> ChangeRequestStatus(StatusRequestDto newStatus, CancellationToken cancellationToken)
        { 
            var request = await _repository.GetRequestById(newStatus.Id, cancellationToken);

            if (request == null)
            {
                return false;
            }
            if (request.ExpertId == null)
            {
                newStatus.Status = StatusRequestEnum.AwaitingSuggestionExperts; 
            }

            if (request.Bids != null)
            {
                newStatus.Status = StatusRequestEnum.AwaitingCustomerConfirmation;

            }

            if (request.DoneAt != null)
            {
                newStatus.Status = StatusRequestEnum.Success;
            }

            if (request.Canccell = true)
            {
                newStatus.Status = StatusRequestEnum.CancelledByExpert;
            
            }
            else
            {
                newStatus.Status = StatusRequestEnum.WaitingForExpert;
                var requet = new RequestAcceptExpertDto()
                {
                    Id = newStatus.Id,
                    Bids = null
                };
                await _repository.AcceptExpert(requet, cancellationToken);
            }
            await _repository.ChangeRequestStatus(newStatus, cancellationToken);

            return true;
        }

    }
}
