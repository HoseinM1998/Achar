using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Request
{
    public interface IRequestRepository
    {
        Task<int> CreateRequest(Entites.Request request, CancellationToken cancellationToken);
        Task<bool> UpdateRequest(Entites.Request request, CancellationToken cancellationToken);
        Task<Entites.Request> GetRequestById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Request>> GetRequests(CancellationToken cancellationToken);
        Task<bool> IsActiveRequest(int id, bool active, CancellationToken cancellationToken);
        public Task<Entites.Request> ChangeServiceRequestStatus(Entites.Request newStatus, CancellationToken cancellationToken);

    }
}
