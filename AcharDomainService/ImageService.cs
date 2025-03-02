using System.Net.Http.Headers;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class ImageService : IImageService
    {

        private readonly IImageRepository _repository;
        public ImageService(IImageRepository repository)
        {
            _repository = repository;
        }


        public async Task AddAdvImages(List<string> imgAddress, int requestId, CancellationToken cancellationToken)
        {
            await _repository.AddAdvImages(imgAddress, requestId, cancellationToken);
        }
        public async Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellation)
        {
            string filePath;
            string fileName;
            if (FormFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine("wwwroot", "assets","img", folderName, fileName);
                try
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await FormFile.CopyToAsync(stream, cancellation);
                    }
                }
                catch
                {
                    throw new Exception("Upload files operation failed");
                }
                return $"/assets/img/{folderName}/{fileName}";
            }
            else
                fileName = "";

            return fileName;
        }

    }
}
