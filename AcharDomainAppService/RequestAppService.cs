using AcharDomainCore.Contracts.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _service;
        private readonly IImageService _imageService;
        private readonly ILogger<RequestAppService> _logger;


        public RequestAppService(IRequestService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        public async Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken)
        {
            try
            {
                var request= await _service.CreateRequest(requestDto, cancellationToken);
                var imagesPath = new List<string>();

                if (requestDto.Images is not null)
                {
                    foreach (var image in requestDto.Images)
                    {
                        var imagePath = await _imageService.UploadImage(image, "request", cancellationToken);
                        imagesPath.Add(imagePath);
                    }

                    await _imageService.AddAdvImages(imagesPath, request, cancellationToken);
                }

                return request;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateRequest: {ex.Message}");
            }
        }

        public async Task<bool> UpdateRequest(RequestUpDto requestUpDto, CancellationToken cancellationToken)
        {
            try
            {
                var existingRequest = await _service.GetRequestById(requestUpDto.Id, cancellationToken);
                if (existingRequest is null)
                {
                    throw new Exception("درخواست موردنظر یافت نشد.");
                }
                var imagesPath = existingRequest.ImagePaths?.ToList() ?? new List<string>(); 

                if (requestUpDto.Images is not null && requestUpDto.Images.Any())
                {
                    imagesPath.Clear(); 
                    foreach (var image in requestUpDto.Images)
                    {
                        var imagePath = await _imageService.UploadImage(image, "requestt", cancellationToken);
                        imagesPath.Add(imagePath);
                    }
                }

                requestUpDto.ImagesPath = imagesPath;
                return await _service.UpdateRequest(requestUpDto, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"خطا در به‌روزرسانی درخواست: {ex.Message}");
            }
        }


        public async Task<int> RequestCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.RequestCount( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error RequestCount: {ex.Message}");
            }
        }

        public async Task<RequestGetDto> GetRequestById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetRequestById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetRequestById: {ex.Message}");
            }
        }

        public async Task<List<RequestGetDto?>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetCustomerRequests(customerId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetRequestById: {ex.Message}");
            }
        }

        public async Task<List<RequestGetDto?>> GetRequests(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetRequests( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetRequests: {ex.Message}");
            }
        }

        public async Task<List<RequestGetDto?>> GetRequestsByExpert(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetRequestsByExpert(expertId,cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetRequests: {ex.Message}");
            }
        }

        public async Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteRequest(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteRequest: {ex.Message}");
            }
        }

        public async Task<bool> ChangeRequestStatus(StatusRequestDto newStatus, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.ChangeRequestStatus(newStatus, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UploadImage: {ex.Message}");
            }
        }

        public async Task<bool> AcceptExpert(int id, int expertId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.AcceptExpert(id,expertId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error AcceptExpert: {ex.Message}");
            }
        }

        public async Task<bool> DoneRequest(int requestId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DoneRequest(requestId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DoneRequest: {ex.Message}");
            }
        }

        public async Task<bool> CancellRequest(int requestId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CancellRequest(requestId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DoneRequest: {ex.Message}");
            }
        }
    }
}
