using AcharDomainCore.Contracts.Bid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.AdminDto;
using AcharDomainCore.Entites;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private readonly ILogger<AdminService> _logger;

        public AdminService(IAdminRepository repository, ILogger<AdminService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<int> AdminCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت تعداد مدیران زمان {Time}", DateTime.Now.ToLongTimeString());
            var count = await _repository.AdminCount(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد مدیران دریافت شده: {Count} زمان {Time}", count, DateTime.Now.ToLongTimeString());
            return count;
        }

        public async Task<AdminProfDto> GetAdminById(int adminID, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت مدیر با شناسه: {AdminId} زمان {Time}", adminID, DateTime.Now.ToLongTimeString());
            var admin = await _repository.GetAdminById(adminID, cancellationToken);
            if (admin is null)
            {
                _logger.LogWarning("لایه سرویس: مدیر با شناسه: {AdminId} پیدا نشد زمان {Time}", adminID, DateTime.Now.ToLongTimeString());
                throw new Exception("مدیر پیدا نشد.");
            }
            _logger.LogInformation("لایه سرویس: مدیر با شناسه: {AdminId} با موفقیت دریافت شد زمان {Time}", adminID, DateTime.Now.ToLongTimeString());
            return admin;
        }

        public async Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت موجودی مدیر با شناسه: {AdminId} زمان {Time}", adminID, DateTime.Now.ToLongTimeString());
            var balance = await _repository.GetBalanceAdminById(adminID, cancellationToken);
            _logger.LogInformation("لایه سرویس: موجودی مدیر با شناسه: {AdminId} دریافت شد: {Balance} زمان {Time}", adminID, balance, DateTime.Now.ToLongTimeString());
            return balance;
        }

        public async Task<List<Admin>> GetAllAmin(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت تمامی مدیران زمان {Time}", DateTime.Now.ToLongTimeString());
            var admins = await _repository.GetAllAmin(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد مدیران دریافت شده: {Count} زمان {Time}", admins.Count, DateTime.Now.ToLongTimeString());
            return admins;
        }

        public async Task<bool> UpdateAdmin(AdminProfDto admin, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: بروزرسانی مدیر با شناسه: {AdminId} زمان {Time}", admin.Id, DateTime.Now.ToLongTimeString());
            var result = await _repository.UpdateAdmin(admin, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: بروزرسانی مدیر با شناسه: {AdminId} ناموفق بود زمان {Time}", admin.Id, DateTime.Now.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: مدیر با شناسه: {AdminId} با موفقیت بروزرسانی شد زمان {Time}", admin.Id, DateTime.Now.ToLongTimeString());
            return true;
        }

        public async Task<bool> DeleteAdmin(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: حذف مدیر با شناسه: {AdminId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
            var result = await _repository.DeleteAdmin(id, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: حذف مدیر با شناسه: {AdminId} ناموفق بود زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: مدیر با شناسه: {AdminId} با موفقیت حذف شد زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return true;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: بروزرسانی موجودی مدیر با شناسه: {AdminId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
            var result = await _repository.UpdateBalance(id, balance, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: بروزرسانی موجودی مدیر با شناسه: {AdminId} ناموفق بود زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: موجودی مدیر با شناسه: {AdminId} با موفقیت بروزرسانی شد زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return true;
        }


    }
}
