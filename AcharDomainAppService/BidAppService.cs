using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Entites;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class BidAppService : IBidAppService
    {
        private readonly IBidService _service;
        private readonly ILogger<BidAppService> _logger;

        public BidAppService(IBidService service, ILogger<BidAppService> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<int> CreateBid(BidAddDto bid, CancellationToken cancellationToken)
        {
            try
            {
                if (bid.BidDate != DateTime.MinValue)
                {
                    PersianCalendar persianCalendar = new PersianCalendar();

                    bid.BidDate = new DateTime(
                        bid.BidDate.Year,
                        bid.BidDate.Month,
                        bid.BidDate.Day,
                        persianCalendar
                    );
                }
                else
                {
                    throw new Exception("تاریخ وارد شده نامعتبر است.");
                }
                var bidId = await _service.CreateBid(bid, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: ایجاد پیشنهاد با شناسه: {BidId} زمان {Time}", bidId, DateTime.Now.ToLongTimeString());
                return bidId;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در ایجاد پیشنهاد زمان {Time}: {Message}", DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"خطا : {ex.Message}");
            }
        }

        public async Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.UpdateBid(bid, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: بروزرسانی پیشنهاد با شناسه: {BidId} زمان {Time}", bid.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در بروزرسانی پیشنهاد با شناسه: {BidId} زمان {Time}: {Message}", bid.Id, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error UpdateBid: {ex.Message}");
            }
        }

        public async Task<int> BidCount(CancellationToken cancellationToken)
        {
            try
            {
                var count = await _service.BidCount(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: تعداد پیشنهاد‌ها دریافت شد: {Count} زمان {Time}", count, DateTime.Now.ToLongTimeString());
                return count;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در دریافت تعداد پیشنهاد‌ها زمان {Time}: {Message}", DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error BidCount: {ex.Message}");
            }
        }

        public async Task<List<GetBidDto>> GetBidsByRequestId(int id, CancellationToken cancellationToken)
        {
            try
            {
                var bids = await _service.GetBidsByRequestId(id, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: دریافت پیشنهاد‌ها با شناسه درخواست: {RequestId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return bids;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در دریافت پیشنهاد‌ها با شناسه درخواست: {RequestId} زمان {Time}: {Message}", id, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error GetBidsByRequestId: {ex.Message}");
            }
        }

        public async Task<List<GetBidDto>> GetBidsByExpertId(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var bids = await _service.GetBidsByExpertId(expertId, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: دریافت پیشنهاد‌ها با شناسه کارشناس: {ExpertId} زمان {Time}", expertId, DateTime.Now.ToLongTimeString());
                return bids;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در دریافت پیشنهاد‌ها با شناسه کارشناس: {ExpertId} زمان {Time}: {Message}", expertId, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error GetBidsByExpertId: {ex.Message}");
            }
        }

        public async Task<List<GetBidDto?>> GetBids(CancellationToken cancellationToken)
        {
            try
            {
                var bids = await _service.GetBids(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: تعداد پیشنهاد‌های دریافت شده: {Count} زمان {Time}", bids.Count, DateTime.Now.ToLongTimeString());
                return bids;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در دریافت پیشنهاد‌ها زمان {Time}: {Message}", DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error GetBids: {ex.Message}");
            }
        }

        public async Task<bool> DeleteBid(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.DeleteBid(delete, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: حذف پیشنهاد با شناسه: {BidId} زمان {Time}", delete.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در حذف پیشنهاد با شناسه: {BidId} زمان {Time}: {Message}", delete.Id, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error DeleteBid: {ex.Message}");
            }
        }

        public async Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.ChangebidStatus(status, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: تغییر وضعیت پیشنهاد با شناسه: {BidId} زمان {Time}", status.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در تغییر وضعیت پیشنهاد با شناسه: {BidId} زمان {Time}: {Message}", status.Id, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error ChangebidStatus: {ex.Message}");
            }
        }

        public async Task<bool> CancellBid(int bidId, int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.CancellBid(bidId,expertId, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CancellBid: {ex.Message}");
            }
        }
    }
}
