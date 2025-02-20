using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Expert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Entites;
using AcharDomainCore.Contracts.Image;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _service;
        private readonly IImageService _imageService;
        private readonly ILogger<ExpertAppService> _logger;

        public ExpertAppService(IExpertService service, IImageService imageService, ILogger<ExpertAppService> logger)
        {
            _service = service;
            _imageService = imageService;
            _logger = logger;
        }

        public async Task<bool> UpdateExpert(ExpertProfDto expert, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی کارشناس با شناسه: {ExpertId} زمان {Time}", expert.Id, DateTime.Now.ToLongTimeString());
                if (expert.ImageFile is not null)
                {
                    expert.ProfileImageUrl = await _imageService.UploadImage(expert.ImageFile!, "user", cancellationToken);
                }
                var result = await _service.UpdateExpert(expert, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی کارشناس با موفقیت انجام شد با شناسه: {ExpertId} زمان {Time}", expert.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در به‌روزرسانی کارشناس: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error UpdateExpert: {ex.Message}");
            }
        }

        public async Task<int> ExpertCount(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات شمارش کارشناسان زمان {Time}", DateTime.Now.ToLongTimeString());
                var result = await _service.ExpertCount(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات شمارش کارشناسان با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در عملیات شمارش کارشناسان: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error ExpertCount: {ex.Message}");
            }
        }

        public async Task<ExpertProfDto?> GetExpertById(int id, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: دریافت کارشناس با شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                var result = await _service.GetExpertById(id, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: دریافت کارشناس با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت کارشناس: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetExpertById: {ex.Message}");
            }
        }

        public async Task<decimal> GetBalanceExpertById(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: دریافت موجودی کارشناس با شناسه: {ExpertId} زمان {Time}", expertId, DateTime.Now.ToLongTimeString());
                var result = await _service.GetBalanceExpertById(expertId, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: دریافت موجودی کارشناس با موفقیت انجام شد برای شناسه: {ExpertId} زمان {Time}", expertId, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت موجودی کارشناس: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetBalanceExpertById: {ex.Message}");
            }
        }

        public async Task<List<ExpertProfDto>?> GetExperts(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات دریافت همه کارشناسان زمان {Time}", DateTime.Now.ToLongTimeString());
                var result = await _service.GetExperts(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات دریافت همه کارشناسان با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت همه کارشناسان: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetExperts: {ex.Message}");
            }
        }

        public async Task<bool> DeleteExpert(int id, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات حذف کارشناس با شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                var result = await _service.DeleteExpert(id, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات حذف کارشناس با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در حذف کارشناس: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error DeleteExpert: {ex.Message}");
            }
        }

        public async Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: فعال‌سازی/غیرفعال‌سازی کارشناس با شناسه: {Id} زمان {Time}", activeDto.Id, DateTime.Now.ToLongTimeString());
                var result = await _service.IActiveExpert(activeDto, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: فعال‌سازی/غیرفعال‌سازی کارشناس با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", activeDto.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در فعال‌سازی/غیرفعال‌سازی کارشناس: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error IActiveExpert: {ex.Message}");
            }
        }

        public async Task<List<ExpertProfDto?>> GetTopExpertsByScore(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات دریافت برترین کارشناسان بر اساس امتیاز زمان {Time}", DateTime.Now.ToLongTimeString());
                var result = await _service.GetTopExpertsByScore(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات دریافت برترین کارشناسان بر اساس امتیاز با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت برترین کارشناسان بر اساس امتیاز: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetTopExpertsByScore: {ex.Message}");
            }
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی موجودی کارشناس با شناسه: {ExpertId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                var result = await _service.UpdateBalance(id, balance, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی موجودی کارشناس با موفقیت انجام شد با شناسه: {ExpertId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در به‌روزرسانی موجودی کارشناس: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error UpdateBalance: {ex.Message}");
            }
        }
    }
}
