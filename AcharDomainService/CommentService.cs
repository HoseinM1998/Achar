using AcharDomainCore.Contracts.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Entites;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly ILogger<CommentService> _logger;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateComment(CommentDto comment, CancellationToken cancellationToken)
            => await _repository.CreateComment(comment, cancellationToken);

        public async Task<bool> UpdateComment(CommentDto comment, CancellationToken cancellationToken)
            => await _repository.UpdateComment(comment, cancellationToken);

        public async Task<int> CommentCount(CancellationToken cancellationToken)
            => await _repository.CommentCount(cancellationToken);

        public async Task<Comment> GetCommentById(int id, CancellationToken cancellationToken)
            => await _repository.GetCommentById(id, cancellationToken);

        public async Task<List<AllCommentDto?>> GetAllComment(CancellationToken cancellationToken)
            => await _repository.GetAllComment(cancellationToken);

        public async Task<List<GetCommentDto>>? GetCommentsByExpertId(int expertId, CancellationToken cancellationToken)
            => await _repository.GetCommentsByExpertId(expertId, cancellationToken);


        public async Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken)
            => await _repository.AcceptComment(commentAcceptDto, cancellationToken);

        public async Task<bool> DeleteComment(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteComment(delete, cancellationToken);
    }
}
