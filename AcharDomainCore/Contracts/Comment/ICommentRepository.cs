using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Comment
{
    public interface ICommentRepository
    {
        Task<int> CreateComment(Entites.Comment comment,CancellationToken cancellationToken);
        Task<bool> UpdateComment(Entites.Comment comment, CancellationToken cancellationToken);
        Task<Entites.Comment> GetCommentById(int id, CancellationToken cancellationToken);
        public Task<List<Entites.Comment>> GetCommentsByExpertId(int expertId, CancellationToken cancellationToken);
        Task<List<Entites.Comment>> GetAllComment(CancellationToken cancellationToken);
        Task<bool> AcceptComment(int id,bool accept,CancellationToken  cancellationToken);
        Task<bool> IsActiveComment(int id,CancellationToken cancellationToken);

    }
}
