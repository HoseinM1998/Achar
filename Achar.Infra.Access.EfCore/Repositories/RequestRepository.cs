using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;
using AcharDomainCore.Dtos.HomeServiceDto;
using HomeService.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class RequestRepository:IRequestRepository
    {
        private readonly AppDbContext _context;
        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken)
        {
            var request = new Request()
            {
                Title = requestDto.Title,
                Description = requestDto.Description,
                Price = requestDto.Price,
                Status = StatusRequestEnum.AwaitingSuggestionExperts,
                RequesteForTime = requestDto.RequesteForTime,
                CustomerId = requestDto.CustomerId,
                HomeServiceId = requestDto.ServiceId
            };
            await _context.Requests.AddAsync(request, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }

        public async Task<bool> UpdateRequest(Request upRequest, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.FindAsync(upRequest.Id, cancellationToken);
            if (request is null) return false;
            request.Title = upRequest.Title;
            request.Description = upRequest.Description;
            request.Price = upRequest.Price;
            request.RequesteForTime = upRequest.RequesteForTime;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Request> GetRequestById(int id, CancellationToken cancellationToken)
        {
            return await _context.Requests.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        }

        public async Task<List<Request>> GetRequests(CancellationToken cancellationToken)
        {
            return await _context.Requests.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<bool> DeleteRequest(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.FindAsync(active.Id, cancellationToken);
            if (request is null) return false;
            request.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> AcceptRequestStatus(AcceptExpertDto acceptExpertDto, CancellationToken cancellationToken)
        {
            var acceptRequest = await _context.Requests.FindAsync(acceptExpertDto.Id, cancellationToken);
            if (acceptRequest is null) return false;
            acceptRequest.AcceptedExpertId = acceptExpertDto.AcceptedExpertId;
            acceptRequest.Status = StatusRequestEnum.WaitingForExpert;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
