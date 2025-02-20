using AcharDomainCore.Contracts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Entites;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class ExpertService :IExpertService
    {
        private readonly IExpertRepository _repository;
        private readonly ILogger<ExpertService> _logger;

        public ExpertService(IExpertRepository repository, ILogger<ExpertService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> UpdateExpert(ExpertProfDto expert, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: بروزرسانی کارشناس با شناسه: {ExpertId} زمان {Time}", expert.Id, DateTime.Now.ToLongTimeString());
            var result = await _repository.UpdateExpert(expert, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: بروزرسانی کارشناس با شناسه: {ExpertId} ناموفق بود زمان {Time}", expert.Id, DateTime.Now.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: کارشناس با شناسه: {ExpertId} با موفقیت بروزرسانی شد زمان {Time}", expert.Id, DateTime.Now.ToLongTimeString());
            return true;
        }

        public async Task<int> ExpertCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت تعداد کارشناسان زمان {Time}", DateTime.Now.ToLongTimeString());
            var count = await _repository.ExpertCount(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد کارشناسان دریافت شده: {Count} زمان {Time}", count, DateTime.Now.ToLongTimeString());
            return count;
        }

        public async Task<ExpertProfDto?> GetExpertById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت کارشناس با شناسه: {ExpertId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
            var expert = await _repository.GetExpertById(id, cancellationToken);
            if (expert is null)
            {
                _logger.LogWarning("لایه سرویس: کارشناس با شناسه: {ExpertId} پیدا نشد زمان {Time}", id, DateTime.Now.ToLongTimeString());
                throw new Exception("کارشناس پیدا نشد.");
            }
            _logger.LogInformation("لایه سرویس: کارشناس با شناسه: {ExpertId} با موفقیت دریافت شد زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return expert;
        }

        public async Task<decimal> GetBalanceExpertById(int expertId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت موجودی کارشناس با شناسه: {ExpertId} زمان {Time}", expertId, DateTime.Now.ToLongTimeString());
            var balance = await _repository.GetBalanceExpertById(expertId, cancellationToken);
            _logger.LogInformation("لایه سرویس: موجودی کارشناس با شناسه: {ExpertId} دریافت شد: {Balance} زمان {Time}", expertId, balance, DateTime.Now.ToLongTimeString());
            return balance;
        }

        public async Task<List<ExpertProfDto>?> GetExperts(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت تمامی کارشناسان زمان {Time}", DateTime.Now.ToLongTimeString());
            var experts = await _repository.GetExperts(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد کارشناسان دریافت شده: {Count} زمان {Time}", experts?.Count, DateTime.Now.ToLongTimeString());
            return experts;
        }

        public async Task<bool> DeleteExpert(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: حذف کارشناس با شناسه: {ExpertId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
            var result = await _repository.DeleteExpert(id, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: حذف کارشناس با شناسه: {ExpertId} ناموفق بود زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: کارشناس با شناسه: {ExpertId} با موفقیت حذف شد زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return true;
        }

        public async Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: فعال/غیرفعال کردن کارشناس با شناسه: {ExpertId} زمان {Time}", activeDto.Id, DateTime.Now.ToLongTimeString());
            var result = await _repository.IActiveExpert(activeDto, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: فعال/غیرفعال کردن کارشناس با شناسه: {ExpertId} ناموفق بود زمان {Time}", activeDto.Id, DateTime.Now.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: کارشناس با شناسه: {ExpertId} با موفقیت فعال/غیرفعال شد زمان {Time}", activeDto.Id, DateTime.Now.ToLongTimeString());
            return true;
        }

        public async Task<List<ExpertProfDto?>> GetTopExpertsByScore(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت برترین کارشناسان بر اساس امتیاز زمان {Time}", DateTime.Now.ToLongTimeString());
            var topExperts = await _repository.GetTopExpertsByScore(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد برترین کارشناسان دریافت شده: {Count} زمان {Time}", topExperts?.Count, DateTime.Now.ToLongTimeString());
            return topExperts;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: بروزرسانی موجودی کارشناس با شناسه: {ExpertId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
            var result = await _repository.UpdateBalance(id, balance, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: بروزرسانی موجودی کارشناس با شناسه: {ExpertId} ناموفق بود زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: موجودی کارشناس با شناسه: {ExpertId} با موفقیت بروزرسانی شد زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return true;
        }


    }
}
