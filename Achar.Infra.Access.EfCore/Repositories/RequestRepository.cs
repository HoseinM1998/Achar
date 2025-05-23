﻿using System.Security.Cryptography.X509Certificates;
using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;
using AcharDomainCore.Enums;
using Microsoft.EntityFrameworkCore;
using Request = AcharDomainCore.Entites.Request;
using Microsoft.Extensions.Logging;
using Azure.Core;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<RequestRepository> _logger;

        public RequestRepository(AppDbContext context, ILogger<RequestRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد درخواست با عنوان: {Title} زمان {Time}", requestDto.Title, DateTime.UtcNow.ToLongTimeString());
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
            _logger.LogInformation("درخواست ایجاد شد با شناسه: {RequestId} زمان {Time}", request.Id, DateTime.UtcNow.ToLongTimeString());
            return request.Id;
        }

        public async Task<bool> UpdateRequest(RequestUpDto upRequest, CancellationToken cancellationToken)
        {
            _logger.LogInformation("بروزرسانی درخواست با شناسه: {RequestId} زمان {Time}", upRequest.Id, DateTime.UtcNow.ToLongTimeString());
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == upRequest.Id, cancellationToken);
            if (request is null)
            {
                _logger.LogWarning("درخواست با شناسه: {RequestId} پیدا نشد زمان {Time}", upRequest.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            request.Title = upRequest.Title;
            request.Description = upRequest.Description;
            request.Price = upRequest.Price;
            request.RequesteForTime = upRequest.RequesteForTime;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("درخواست با شناسه: {RequestId} با موفقیت بروزرسانی شد زمان {Time}", upRequest.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<int> RequestCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تعداد درخواست‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.Requests
                .AsNoTracking()
                .Where(request => request.IsDeleted == false)
                .CountAsync(cancellationToken);
            _logger.LogInformation("تعداد درخواست‌ها: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }


        public async Task<RequestGetDto> GetRequestById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت درخواست با شناسه: {RequestId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var request = await _context.Requests
                .AsNoTracking()
                .Include(r => r.Customer)
                .ThenInclude(x => x.ApplicationUser)
                .Include(r => r.HomeService)
                .Include(r => r.AcceptedExpert)
                .ThenInclude(x => x.ApplicationUser)
                .Include(r => r.Images)
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
            if (request is null)
            {
                _logger.LogWarning("درخواست با شناسه: {RequestId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("درخواست پیدا نشد.");
            }
            _logger.LogInformation("درخواست با شناسه: {RequestId} با موفقیت دریافت شد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            return new RequestGetDto
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                ImagePaths = request.Images.Select(img => img.ImgPath).ToList(), 
                Status = request.Status,
                RequesteForTime = request.RequesteForTime,
                CreateAt = request.CreateAt,
                CustomerId = request.CustomerId,
                DoneAt = request.DoneAt,
                CustomerName = request.Customer.ApplicationUser.FirstName + " " + request.Customer.ApplicationUser.LastName,
                ServiceId = request.HomeServiceId,
                HomeServiceName = request.HomeService?.Title,
                ExpertId = request.AcceptedExpertId,
                ExpertName = request.Customer.ApplicationUser.FirstName + " " + request.Customer.ApplicationUser.LastName
            };
        }

        public async Task<List<RequestGetDto?>> GetRequests(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی درخواست‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var requests = await _context.Requests.OrderByDescending(x => x.CreateAt)
                .AsNoTracking()
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
                    ImagePaths = r.Images.Select(img => img.ImgPath).ToList(),
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
            _logger.LogInformation("تعداد درخواست‌های دریافت شده: {Count} زمان {Time}", requests.Count, DateTime.UtcNow.ToLongTimeString());
            return requests;
        }

        public async Task<List<RequestGetDto?>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests.OrderByDescending(x => x.CreateAt).AsNoTracking()
                .Where(r => r.CustomerId == customerId)
                .Include(r => r.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(r => r.HomeService)
                .Include(r => r.AcceptedExpert)
                .ThenInclude(e => e.ApplicationUser)
                .Include(r => r.Images)
                .Include(r => r.Bids)
                .ThenInclude(r => r.Expert)
                .ThenInclude(r => r.ApplicationUser)
                .Select(r => new RequestGetDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Price = r.Price,
                    DoneAt = r.DoneAt,
                    ImagePaths = r.Images.Select(img => img.ImgPath).ToList(),
                    Status = r.Status,
                    RequesteForTime = r.RequesteForTime,
                    CreateAt = r.CreateAt,
                    CustomerId = r.CustomerId,
                    CustomerName = r.Customer.ApplicationUser.FirstName + " " + r.Customer.ApplicationUser.LastName,
                    ServiceId = r.HomeServiceId,
                    HomeServiceName = r.HomeService.Title,
                    ExpertId = r.AcceptedExpertId,
                    ExpertName = r.AcceptedExpert.ApplicationUser.FirstName + " " + r.AcceptedExpert.ApplicationUser.LastName,
                    Bids = r.Bids.ToList()

                })
                .ToListAsync(cancellationToken);
            return requests;
        }

        public async Task<List<RequestGetDto>> GetRequestsByExpert(int expertId, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts
                .AsNoTracking()
                .Include(e => e.Skills)
                .Include(e => e.City)
                .FirstOrDefaultAsync(e => e.Id == expertId, cancellationToken);

            if (expert is null || !expert.IsActive)
            {
                return new List<RequestGetDto>();
            }

            var skillIds = expert.Skills.Select(s => s.Id).ToList();

            var requests = await _context.Requests
                .AsNoTracking()
                .OrderByDescending(r => r.CreateAt)
                .Where(r =>
                    skillIds.Contains(r.HomeServiceId) &&
                    r.Customer.CityId == expert.CityId &&
                    (r.Status == StatusRequestEnum.AwaitingSuggestionExperts ||
                     r.Status == StatusRequestEnum.AwaitingCustomerConfirmation) &&
                    !r.Bids.Any(s => s.ExpertId == expertId)) 
                .Select(r => new RequestGetDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Price = r.Price,
                    ImagePaths = r.Images.Select(img => img.ImgPath).ToList(),
                    Status = r.Status,
                    RequesteForTime = r.RequesteForTime,
                    CreateAt = r.CreateAt,
                    CustomerId = r.CustomerId,
                    CustomerName = r.Customer.ApplicationUser.FirstName + " " + r.Customer.ApplicationUser.LastName,
                    ServiceId = r.HomeServiceId,
                    HomeServiceName = r.HomeService.Title,
                    ExpertId = r.AcceptedExpertId,
                    ExpertName = r.AcceptedExpert != null
                        ? r.AcceptedExpert.ApplicationUser.FirstName + " " + r.AcceptedExpert.ApplicationUser.LastName
                        : null
                })
                .ToListAsync(cancellationToken);

            return requests;
        }


        public async Task<bool> DeleteRequest(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            _logger.LogInformation("حذف درخواست با شناسه: {RequestId} زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == active.Id, cancellationToken);
            if (request is null)
            {
                _logger.LogWarning("درخواست با شناسه: {RequestId} پیدا نشد زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            request.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("درخواست با شناسه: {RequestId} حذف شد{Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<bool> ChangeRequestStatus(StatusRequestDto statusRequest, CancellationToken cancellationToken)
        {
            _logger.LogInformation("تغییر وضعیت درخواست با شناسه: {RequestId} زمان {Time}", statusRequest.Id, DateTime.UtcNow.ToLongTimeString());
            var acceptRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == statusRequest.Id, cancellationToken);
            if (acceptRequest is null)
            {
                _logger.LogWarning("درخواست با شناسه: {RequestId} پیدا نشد زمان {Time}", statusRequest.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            acceptRequest.Status = statusRequest.Status;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("وضعیت درخواست با شناسه: {RequestId} با موفقیت تغییر یافت زمان {Time}", statusRequest.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<bool> AcceptExpert(int id, int bidId, CancellationToken cancellationToken)
        {
            var acceptRequest = await _context.Requests
                .Include(x => x.Bids)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (acceptRequest is null)
            {
                return false;
            }

            if (acceptRequest.AcceptedExpertId != null)
            {
                return false;
            }
            acceptRequest.Status = StatusRequestEnum.WaitingForExpert;
            var acceptedBid = await _context.Bids.FirstOrDefaultAsync(x => x.Id == bidId);
            if (acceptedBid is null)
            {
                return false;
            }
            acceptRequest.AcceptedExpertId = acceptedBid.ExpertId;
            acceptedBid.Status = StatusBidEnum.WaitingForExpert;
            var rejectedBids = acceptRequest.Bids.Where(b => b.Id != bidId).ToList();
            foreach (var bid in rejectedBids)
            {
                bid.Status = StatusBidEnum.Rejected;
            }
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }


        public async Task<bool> DoneRequest(int requestId, CancellationToken cancellationToken)
        {
            var acceptRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellationToken);
            if (acceptRequest is null)
            {
                return false;
            }
            acceptRequest.Status = StatusRequestEnum.Success;
            acceptRequest.DoneAt = DateTime.Now;
            var bid = await _context.Bids.FirstOrDefaultAsync(x => x.RequestId == acceptRequest.Id, cancellationToken);
            if (bid is null)
            {
                return false;
            }
            bid.Status = StatusBidEnum.Success;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> CancellRequest(int requestId, CancellationToken cancellationToken)
        {
            var acceptRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellationToken);
            if (acceptRequest is null)
            {
                return false;
            }
            acceptRequest.Status = StatusRequestEnum.CancelledByCustomer;
            var bid = await _context.Bids.FirstOrDefaultAsync(x => x.RequestId == acceptRequest.Id, cancellationToken); 
            if (bid is null)
            {
                return false;
            }
            bid.Status = StatusBidEnum.CancelledByCustomer;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
