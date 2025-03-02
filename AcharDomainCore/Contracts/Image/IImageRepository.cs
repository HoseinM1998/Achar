using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Image
{
    public interface IImageRepository
    {
        Task AddAdvImages(List<string> imgAddress, int advId, CancellationToken cancellationToken);
    }
}
