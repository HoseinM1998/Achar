using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CommentRepository> _logger;

        public CommentRepository(AppDbContext context, ILogger<CommentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateComment(CommentDto commentDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد نظر با عنوان: {Title} زمان {Time}", commentDto.Title, DateTime.UtcNow.ToLongTimeString());
            var comment = new Comment()
            {
                CreateAt = DateTime.Now,
                Title = commentDto.Title,
                Description = commentDto.Description,
                Score = commentDto.Score,
                CustomerId = commentDto.CustomerId,
                ExpertId = commentDto.ExpertId,
            };

            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("نظر ایجاد شد با شناسه: {CommentId} زمان {Time}", comment.Id, DateTime.UtcNow.ToLongTimeString());
            return comment.Id;
        }

        public async Task<bool> UpdateComment(CommentDto commentDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("بروزرسانی نظر با شناسه: {CommentId} زمان {Time}", commentDto.Id, DateTime.UtcNow.ToLongTimeString());
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentDto.Id, cancellationToken);
            if (comment is null)
            {
                _logger.LogWarning("نظر با شناسه: {CommentId} پیدا نشد زمان {Time}", commentDto.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            comment.Title = commentDto.Title;
            comment.Description = commentDto.Description;
            comment.Score = commentDto.Score;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("نظر با شناسه: {CommentId} با موفقیت بروزرسانی شد زمان {Time}", commentDto.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<int> CommentCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تعداد نظرات زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.Comments
                .AsNoTracking()
                .Where(comment => comment.IsDeleted == false)
                .CountAsync(cancellationToken);
            _logger.LogInformation("تعداد نظرات: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }


        public async Task<Comment> GetCommentById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت نظر با شناسه: {CommentId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var comment = await _context.Comments.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (comment is null)
            {
                _logger.LogWarning("نظر با شناسه: {CommentId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("نظر پیدا نشد.");
            }
            _logger.LogInformation("نظر با شناسه: {CommentId} با موفقیت دریافت شد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            return comment;
        }

        public async Task<List<AllCommentDto?>> GetAllComment(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی نظرات زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var comments = await _context.Comments
                .Include(c => c.Expert)
                .ThenInclude(c => c.ApplicationUser)
                .Include(c => c.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Select(c => new AllCommentDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Score = c.Score,
                    IsAccept = c.IsAccept,
                    CreateAt = c.CreateAt,
                    CustomerId = c.CustomerId,
                    CustomerName = c.Customer.ApplicationUser.FirstName + " " + c.Customer.ApplicationUser.LastName,
                    ExpertId = c.ExpertId,
                    ExpertName = c.Expert.ApplicationUser.FirstName + " " + c.Expert.ApplicationUser.LastName
                })
                .ToListAsync(cancellationToken);
            _logger.LogInformation("تعداد نظرات دریافت شده: {Count} زمان {Time}", comments.Count, DateTime.UtcNow.ToLongTimeString());
            return comments;
        }

        public async Task<List<GetCommentDto>>? GetCommentsByExpertId(int expertId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت نظرات با شناسه کارشناس: {ExpertId} زمان {Time}", expertId, DateTime.UtcNow.ToLongTimeString());
            var comments = await _context.Comments
                .Include(c => c.Expert)
                .ThenInclude(c => c.ApplicationUser)
                .Include(c => c.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Select(c => new GetCommentDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Score = c.Score,
                    CustomerName = c.Customer.ApplicationUser.FirstName + " " + c.Customer.ApplicationUser.LastName,
                    ExpertName = c.Expert.ApplicationUser.FirstName + " " + c.Expert.ApplicationUser.LastName,
                    CreatAt = c.CreateAt
                })
                .ToListAsync(cancellationToken);
            _logger.LogInformation("نظرات با شناسه کارشناس: {ExpertId} دریافت شدند زمان {Time}", expertId, DateTime.UtcNow.ToLongTimeString());
            return comments;
        }

        public async Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("تایید نظر با شناسه: {CommentId} زمان {Time}", commentAcceptDto.Id, DateTime.UtcNow.ToLongTimeString());
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentAcceptDto.Id, cancellationToken);
            if (comment is null)
            {
                _logger.LogWarning("نظر با شناسه: {CommentId} پیدا نشد زمان {Time}", commentAcceptDto.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            comment.IsAccept = commentAcceptDto.IsAccept;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("نظر با شناسه: {CommentId} تایید شد زمان {Time}", commentAcceptDto.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<bool> DeleteComment(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            _logger.LogInformation("حذف نظر با شناسه: {CommentId} زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == active.Id, cancellationToken);
            if (comment is null)
            {
                _logger.LogWarning("نظر با شناسه: {CommentId} پیدا نشد زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            comment.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("نظر با شناسه: {CommentId} به حالت حذف شده تغییر یافت زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }
    }
}
