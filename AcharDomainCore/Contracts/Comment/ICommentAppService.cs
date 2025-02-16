using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Comment
{
    public interface ICommentAppService
    {
        Task<int> CreateComment(CommentDto comment, CancellationToken cancellationToken);
        Task<bool> UpdateComment(CommentDto comment, CancellationToken cancellationToken);
        Task<int> CommentCount(CancellationToken cancellationToken);
        Task<Entites.Comment> GetCommentById(int id, CancellationToken cancellationToken);
        Task<List<AllCommentDto?>> GetAllComment(CancellationToken cancellationToken);
        public Task<List<GetCommentDto>>? GetCommentsByExpertId(int expertId, CancellationToken cancellationToken);
        Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken);
        Task<bool> DeleteComment(SoftDeleteDto delete, CancellationToken cancellationToken);
    }
}
