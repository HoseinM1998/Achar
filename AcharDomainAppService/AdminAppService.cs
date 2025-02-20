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
    public class AdminAppService:IAdminAppService
    {
        private readonly IAdminService _service;
        private readonly IImageService _imageService;
        private readonly ILogger<AdminAppService> _logger;


        public AdminAppService(IAdminService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;

        }
        public async Task<int> AdminCount(CancellationToken cancellationToken)
        {
            try
            {

                return await _service.AdminCount( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateBid: {ex.Message}");
            }
        }

        public async Task<AdminProfDto> GetAdminById(int adminID, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetAdminById(adminID,cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetAdminById: {ex.Message}");
            }
        }

        public async Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetBalanceAdminById(adminID,cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetBalanceAdminById: {ex.Message}");
            }
        }

        public async Task<List<Admin>> GetAllAmin(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetAllAmin(cancellationToken);
            }
            catch (Exception ex)
            {
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
                return await _service.UpdateAdmin(admin,cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateAdmin: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAdmin(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteAdmin(id,cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteAdmin: {ex.Message}");
            }
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateBalance(id,balance,cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateBalance: {ex.Message}");
            }
        }
    }
}
