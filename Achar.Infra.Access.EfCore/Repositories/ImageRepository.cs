using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Entites;
using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.Image;
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class ImageRepository : IImageRepository
    {

        private readonly AppDbContext _context;
        public ImageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAdvImages(List<string> imgAddress, int requestId, CancellationToken cancellationToken)
        {
            var images = imgAddress.Select(x => new Image()
            {
                ImgPath = x,
                RequestId = requestId
            });

            await _context.Images.AddRangeAsync(images, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
