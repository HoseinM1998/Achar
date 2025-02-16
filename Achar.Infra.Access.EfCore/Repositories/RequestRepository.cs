using Achar.Infra.Db.Sql;

using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;
using HomeService.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Request = AcharDomainCore.Entites.Request;

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
                CreateAt = DateTime.Now,
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
            if (requestDto.Images != null && requestDto.Images.Any())
            {
                var images = requestDto.Images.Select(img => new Image
                {
                    Title = img.Title,
                    ImgPath = img.ImgPath,
                    RequestId = request.Id 
                }).ToList();
                await _context.Images.AddRangeAsync(images, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken); 
            }
            return request.Id;
        }

        public async Task<bool> UpdateRequest(RequestUpDto upRequest, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.FindAsync(upRequest.Id, cancellationToken);
            if (request is null) return false;
            request.Title = upRequest.Title;
            request.Description = upRequest.Description;
            request.Price = upRequest.Price;
            request.RequesteForTime = upRequest.RequesteForTime;
            if (request.Images != null && upRequest.Images.Any())
            {
                var images = upRequest.Images.Select(img => new Image
                {
                    Title = img.Title,
                    ImgPath = img.ImgPath,
                    RequestId = request.Id
                }).ToList();
                await _context.Images.AddRangeAsync(images, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<int> RequestCount(CancellationToken cancellationToken)
        {
            return await _context.Requests.AsNoTracking().CountAsync(cancellationToken);

        }

        public async Task<RequestGetDto> GetRequestById(int id, CancellationToken cancellationToken)
        {

            var request = await _context.Requests
                .Include(r => r.Customer)
                .ThenInclude(x=>x.ApplicationUser)
                .Include(r => r.HomeService)
                .Include(r => r.AcceptedExpert)
                .ThenInclude(x=>x.ApplicationUser)
                .Include(r => r.Images) 
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

            
            return new RequestGetDto
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Images = request.Images?.ToList() ?? new List<Image>(), 
                Status = request.Status,
                RequesteForTime = request.RequesteForTime,
                CreateAt = request.CreateAt,
                CustomerId = request.CustomerId,
                CustomerName = request.Customer.ApplicationUser.FirstName+" "+request.Customer.ApplicationUser.LastName, 
                ServiceId = request.HomeServiceId,
                HomeServiceName = request.HomeService?.Title,
                ExpertId = request.AcceptedExpertId,
                ExpertName = request.Customer.ApplicationUser.FirstName + " " + request.Customer.ApplicationUser.LastName
            };
        }

        public async Task<List<RequestGetDto?>> GetRequests(CancellationToken cancellationToken)
        {
            var requests = await _context.Requests
                .Include(r => r.Customer) 
                .ThenInclude(c => c.ApplicationUser) 
                .Include(r => r.HomeService) 
                .Include(r => r.AcceptedExpert) 
                .ThenInclude(e => e.ApplicationUser) 
                .Include(r => r.Images) 
                .Select(r => new RequestGetDto 
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Price = r.Price,
                    Images = r.Images.ToList(),
                    Status = r.Status,
                    RequesteForTime = r.RequesteForTime,
                    CreateAt = r.CreateAt,
                    CustomerId = r.CustomerId,
                    CustomerName = r.Customer.ApplicationUser.FirstName + " " + r.Customer.ApplicationUser.LastName,
                    ServiceId = r.HomeServiceId,
                    HomeServiceName = r.HomeService.Title,
                    ExpertId = r.AcceptedExpertId,
                    ExpertName = r.Customer.ApplicationUser.FirstName + " " + r.Customer.ApplicationUser.LastName
                  })
                .ToListAsync(cancellationToken);

            return requests;
        }

        public async Task<bool> DeleteRequest(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.FindAsync(active.Id, cancellationToken);
            if (request is null) return false;
            request.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ChangeRequestStatus(StatusRequestDto statusRequest, CancellationToken cancellationToken)
        {
            var acceptRequest = await _context.Requests.FindAsync(statusRequest.Id, cancellationToken);
            if (acceptRequest is null) return false;
            acceptRequest.Status = statusRequest.Status;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
