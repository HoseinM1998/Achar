using System.Net.Http.Headers;
using AcharDomainCore.Contracts.Image;
using Microsoft.AspNetCore.Http;

namespace AcharDomainService
{
    public class ImageService : IImageService
    {
        public async Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellation)
        {
            string filePath;
            string fileName;
            if (FormFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine($"wwwroot/~/UserTemplate/images/{folderName}", fileName);
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
                return $"/~/assets/img/request/{folderName}/{fileName}";
            }
            else
                fileName = "";

            return fileName;
        }

    }
}
