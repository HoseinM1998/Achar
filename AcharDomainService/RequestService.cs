using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.BaseData;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;
using AcharDomainCore.Enums;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        private readonly IBaseRepository _repositoryBalance;

        private readonly ILogger<RequestService> _logger;

        public RequestService(IRequestRepository repository,IBaseRepository repositoryBalance)
        {
            _repository = repository;
            _repositoryBalance = repositoryBalance;
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

        public async Task<List<RequestGetDto?>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
            => await _repository.GetCustomerRequests(customerId,cancellationToken);

        public async Task<List<RequestGetDto?>> GetRequestsByExpert(int expertId, CancellationToken cancellationToken)
            => await _repository.GetRequestsByExpert(expertId, cancellationToken);


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

            else
            {
                newStatus.Status = StatusRequestEnum.WaitingForExpert;
                var requet = new RequestAcceptExpertDto()
                {
                    Id = newStatus.Id,
                    Bids = null
                };
                await _repository.AcceptExpert(requet.Id, requet.ExpertId,cancellationToken);
            }
            await _repository.ChangeRequestStatus(newStatus, cancellationToken);

            return true;
        }

        public async Task<bool> AcceptExpert(int id, int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var requestDto = await _repository.GetRequestById(id, cancellationToken);
                var priceService = await _repositoryBalance.GetPriceHomeService(requestDto.ServiceId, cancellationToken);
                var balanceCustomer = await _repositoryBalance.GetBalanceCustomer(requestDto.CustomerId, cancellationToken);

                if (balanceCustomer < priceService)
                {
                    throw new Exception("موجودی کافی نیست");
                    return false;
                }

                if (requestDto.Price < priceService)
                {
                    throw new Exception($"{priceService}مبلغ پیشنهادی باید بزرگتر از");
                    return false;
                }
                await _repositoryBalance.ChangeBalanceCustomer(requestDto.CustomerId, requestDto.Price, cancellationToken);
                await _repositoryBalance.ChangeBalanceAdmin(requestDto.Price, cancellationToken);
                await _repository.AcceptExpert(id, expertId, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Accept: {ex.Message}");
            }
        }


        public async Task<bool> DoneRequest(int requestId, CancellationToken cancellationToken)
        {
            var requestDto = await _repository.GetRequestById(requestId, cancellationToken);
            var priceService = await _repositoryBalance.GetPriceHomeService(requestDto.ServiceId, cancellationToken);
            var balanceCustomer = await _repositoryBalance.GetBalanceCustomer(requestDto.CustomerId, cancellationToken);
            if (balanceCustomer < priceService)
            {
                throw new Exception("Not enough inventory");
                return false;
            }
            if (requestDto.Price < priceService)
            {
                throw new Exception($"Price >{priceService}");
                return false;
            }
            decimal tenPercent = requestDto.Price * 0.1m;
            decimal remainingAmount = requestDto.Price - tenPercent;
            await _repositoryBalance.ChangeBalanceAdminExpert(remainingAmount, cancellationToken);
            await _repositoryBalance.ChangeBalanceExpert(requestDto.ExpertId!.Value, remainingAmount, cancellationToken); ;
            await _repository.DoneRequest(requestId, cancellationToken);
            return true;
        }

        public async Task<bool> CancellRequest(int requestId, CancellationToken cancellationToken)
        {
            var requestDto = await _repository.GetRequestById(requestId, cancellationToken);
            if (requestDto == null)
            {
                throw new Exception("Not Find");
                return false;

            }
            var admin = await _repositoryBalance.ChangeBalanceAdmin(requestDto.Price, cancellationToken);
            var customer = await _repositoryBalance.ChangeAddBalanceCustomer(requestDto.CustomerId,requestDto.Price, cancellationToken);
            await _repository.CancellRequest(requestId, cancellationToken);
            return true;

        }
    }
}
