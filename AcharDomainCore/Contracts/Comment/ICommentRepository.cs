using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.CommentDto;

namespace AcharDomainCore.Contracts.Comment
{
    public interface ICommentRepository
    {
        Task<int> CreateComment(CommentDto comment,CancellationToken cancellationToken);
        Task<bool> UpdateComment(CommentDto comment, CancellationToken cancellationToken);
        Task<Entites.Comment> GetCommentById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Comment>> GetAllComment(CancellationToken cancellationToken);
        Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto,CancellationToken  cancellationToken);
        Task<bool> DeleteComment(SoftDeleteDto delete, CancellationToken cancellationToken);

    }
}
