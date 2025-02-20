using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Image;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.AdminDto;
using AcharDomainCore.Entites;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class AdminAppService : IAdminAppService
    {
        private readonly IAdminService _service;
        private readonly IImageService _imageService;
        private readonly ILogger<AdminAppService> _logger;

        public AdminAppService(IAdminService service, IImageService imageService, ILogger<AdminAppService> logger)
        {
            _service = service;
            _imageService = imageService;
            _logger = logger;
        }

        public async Task<int> AdminCount(CancellationToken cancellationToken)
        {
            try
            {
                var count = await _service.AdminCount(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: تعداد ادمین‌ها دریافت شد: {Count} زمان {Time}", count, DateTime.Now.ToLongTimeString());
                return count;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در دریافت تعداد ادمین‌ها زمان {Time}: {Message}", DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error CreateBid: {ex.Message}");
            }
        }

        public async Task<AdminProfDto> GetAdminById(int adminID, CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _service.GetAdminById(adminID, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: دریافت ادمین با شناسه: {AdminID} زمان {Time}", adminID, DateTime.Now.ToLongTimeString());
                return admin;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در دریافت ادمین با شناسه: {AdminID} زمان {Time}: {Message}", adminID, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error GetAdminById: {ex.Message}");
            }
        }

        public async Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken)
        {
            try
            {
                var balance = await _service.GetBalanceAdminById(adminID, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: دریافت موجودی ادمین با شناسه: {AdminID} زمان {Time}", adminID, DateTime.Now.ToLongTimeString());
                return balance;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در دریافت موجودی ادمین با شناسه: {AdminID} زمان {Time}: {Message}", adminID, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error GetBalanceAdminById: {ex.Message}");
            }
        }

        public async Task<List<Admin>> GetAllAmin(CancellationToken cancellationToken)
        {
            try
            {
                var admins = await _service.GetAllAmin(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: تعداد ادمین‌های دریافت شده: {Count} زمان {Time}", admins.Count, DateTime.Now.ToLongTimeString());
                return admins;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در دریافت همه ادمین‌ها زمان {Time}: {Message}", DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error GetAllAmin: {ex.Message}");
            }
        }

        public async Task<bool> UpdateAdmin(AdminProfDto admin, CancellationToken cancellationToken)
        {
            try
            {
                if (admin.ImageFile is not null)
                {
                    admin.ProfileImageUrl = await _imageService.UploadImage(admin.ImageFile!, "user", cancellationToken);
                }
                var result = await _service.UpdateAdmin(admin, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: بروزرسانی ادمین با شناسه: {AdminID} زمان {Time}", admin.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در بروزرسانی ادمین با شناسه: {AdminID} زمان {Time}: {Message}", admin.Id, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error UpdateAdmin: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAdmin(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.DeleteAdmin(id, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: حذف ادمین با شناسه: {AdminID} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در حذف ادمین با شناسه: {AdminID} زمان {Time}: {Message}", id, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error DeleteAdmin: {ex.Message}");
            }
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.UpdateBalance(id, balance, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: بروزرسانی موجودی ادمین با شناسه: {AdminID} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("لایه اپ سرویس: خطا در بروزرسانی موجودی ادمین با شناسه: {AdminID} زمان {Time}: {Message}", id, DateTime.Now.ToLongTimeString(), ex.Message);
                throw new Exception($"Error UpdateBalance: {ex.Message}");
            }
        }
    }
}
