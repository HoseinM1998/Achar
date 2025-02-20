using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Entites;
using AcharDomainCore.Contracts.Image;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    using AcharDomainCore.Contracts.Comment;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AcharDomainCore.Contracts.Customer;
    using AcharDomainCore.Dtos;
    using AcharDomainCore.Dtos.CustomerDto;
    using AcharDomainCore.Entites;
    using AcharDomainCore.Contracts.Image;
    using Microsoft.Extensions.Logging;

    namespace AcharDomainAppService
    {
        public class CustomerAppService : ICustomerAppService
        {
            private readonly ICustomerService _service;
            private readonly IImageService _imageService;
            private readonly ILogger<CustomerAppService> _logger;

            public CustomerAppService(ICustomerService service, IImageService imageService, ILogger<CustomerAppService> logger)
            {
                _service = service;
                _imageService = imageService;
                _logger = logger;
            }

            public async Task<bool> UpdateCustomer(CustomerProfDto customer, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی مشتری با شناسه: {CustomerId} زمان {Time}", customer.Id, DateTime.Now.ToLongTimeString());
                    if (customer.ImageFile is not null)
                    {
                        customer.ProfileImageUrl = await _imageService.UploadImage(customer.ImageFile!, "user", cancellationToken);
                    }
                    var result = await _service.UpdateCustomer(customer, cancellationToken);
                    _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی مشتری با موفقیت انجام شد با شناسه: {CustomerId} زمان {Time}", customer.Id, DateTime.Now.ToLongTimeString());
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "لایه اپ سرویس: خطا در به‌روزرسانی مشتری: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                    throw new Exception($"Error UpdateCustomer: {ex.Message}");
                }
            }

            public async Task<int> CoustomerCount(CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("لایه اپ سرویس: شروع عملیات شمارش مشتری زمان {Time}", DateTime.Now.ToLongTimeString());
                    var result = await _service.CoustomerCount(cancellationToken);
                    _logger.LogInformation("لایه اپ سرویس: عملیات شمارش مشتری با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "لایه اپ سرویس: خطا در عملیات شمارش مشتری: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                    throw new Exception($"Error CoustomerCount: {ex.Message}");
                }
            }

            public async Task<decimal> GetBalanceCustomerById(int customerId, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("لایه اپ سرویس: دریافت موجودی مشتری با شناسه: {CustomerId} زمان {Time}", customerId, DateTime.Now.ToLongTimeString());
                    var result = await _service.GetBalanceCustomerById(customerId, cancellationToken);
                    _logger.LogInformation("لایه اپ سرویس: دریافت موجودی مشتری با موفقیت انجام شد برای شناسه: {CustomerId} زمان {Time}", customerId, DateTime.Now.ToLongTimeString());
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت موجودی مشتری: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                    throw new Exception($"Error GetBalanceCustomerById: {ex.Message}");
                }
            }

            public async Task<CustomerProfDto> GetCustomerById(int id, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("لایه اپ سرویس: دریافت مشتری با شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                    var result = await _service.GetCustomerById(id, cancellationToken);
                    _logger.LogInformation("لایه اپ سرویس: دریافت مشتری با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت مشتری: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                    throw new Exception($"Error GetCustomerById: {ex.Message}");
                }
            }

            public async Task<List<CustomerGetAll>> GetCustomers(CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("لایه اپ سرویس: شروع عملیات دریافت همه مشتری‌ها زمان {Time}", DateTime.Now.ToLongTimeString());
                    var result = await _service.GetCustomers(cancellationToken);
                    _logger.LogInformation("لایه اپ سرویس: عملیات دریافت همه مشتری‌ها با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت همه مشتری‌ها: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                    throw new Exception($"Error GetCustomers: {ex.Message}");
                }
            }

            public async Task<bool> DeleteCustomer(int delete, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("لایه اپ سرویس: شروع عملیات حذف مشتری با شناسه: {Id} زمان {Time}", delete, DateTime.Now.ToLongTimeString());
                    var result = await _service.DeleteCustomer(delete, cancellationToken);
                    _logger.LogInformation("لایه اپ سرویس: عملیات حذف مشتری با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", delete, DateTime.Now.ToLongTimeString());
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "لایه اپ سرویس: خطا در حذف مشتری: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                    throw new Exception($"Error DeleteCustomer: {ex.Message}");
                }
            }

            public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی موجودی مشتری با شناسه: {CustomerId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                    var result = await _service.UpdateBalance(id, balance, cancellationToken);
                    _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی موجودی مشتری با موفقیت انجام شد با شناسه: {CustomerId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "لایه اپ سرویس: خطا در به‌روزرسانی موجودی مشتری: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                    throw new Exception($"Error UpdateBalance: {ex.Message}");
                }
            }
        }
    }

}
