using AcharDomainCore.Contracts.Expert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Image;
using Microsoft.AspNetCore.Http;
using AcharDomainCore.Entites;

namespace AcharDomainAppService
{
    public class ImageAppService:IImageAppService
    {
        private readonly IImageService _service;
        public ImageAppService(IImageService service)
        {
            _service = service;
        }

        public async Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UploadImage(FormFile,folderName, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UploadImage: {ex.Message}");
            }
        }
    }
}
