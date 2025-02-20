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

namespace AcharDomainAppService
{
    public class CommentAppService:ICommentAppService
    {
        private readonly ICommentService _service;
        private readonly ILogger<CommentAppService> _logger;

        public CommentAppService(ICommentService service)
        {
            _service = service;
        }

        public async Task<int> CreateComment(CommentDto comment, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CreateComment(comment, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateComment: {ex.Message}");
            }
        }

        public async Task<bool> UpdateComment(CommentDto comment, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateComment(comment, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateComment: {ex.Message}");
            }
        }

        public async Task<int> CommentCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CommentCount(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CommentCount: {ex.Message}");
            }
        }

        public async Task<Comment> GetCommentById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetCommentById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetCommentById: {ex.Message}");
            }
        }

        public async Task<List<AllCommentDto?>> GetAllComment(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetAllComment(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetAllComment: {ex.Message}");
            }
        }

        public async Task<List<GetCommentDto>>? GetCommentsByExpertId(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetCommentsByExpertId(expertId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetCommentsByExpertId: {ex.Message}");
            }
        }

        public async Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.AcceptComment(commentAcceptDto, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error AcceptComment: {ex.Message}");
            }
        }

        public async Task<bool> DeleteComment(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteComment(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteComment: {ex.Message}");
            }
        }
    }
}
