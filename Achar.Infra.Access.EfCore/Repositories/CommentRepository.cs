using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Entites;

using Microsoft.EntityFrameworkCore;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateComment(CommentDto commentDto, CancellationToken cancellationToken)
        {
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

            return comment.Id;
        }

        public async Task<bool> UpdateComment(CommentDto commentDto, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(commentDto.Id, cancellationToken);
            if (comment is null) return false;
            comment.Title = commentDto.Title;
            comment.Description = commentDto.Description;
            comment.Score = commentDto.Score;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<int> CommentCount(CancellationToken cancellationToken)
        {
            return await _context.Comments.AsNoTracking().CountAsync(cancellationToken);

        }

        public async Task<Comment> GetCommentById(int id, CancellationToken cancellationToken)
        {
            return await _context.Comments.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<AllCommentDto?>> GetAllComment(CancellationToken cancellationToken)
        {
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
                    CustomerName = c.Customer.ApplicationUser.FirstName+" "+c.Customer.ApplicationUser.LastName, 
                    ExpertId = c.ExpertId,
                    ExpertName = c.Expert.ApplicationUser.FirstName + " " + c.Expert.ApplicationUser.LastName
                })
                .ToListAsync(cancellationToken); 
            return comments;

        }

        public async Task<List<GetCommentDto>>? GetCommentsByExpertId(int expertId, CancellationToken cancellationToken)
        {
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
                    CustomerName = c.Customer.ApplicationUser.FirstName+" "+c.Customer.ApplicationUser.LastName, 
                    ExpertName = c.Expert.ApplicationUser.FirstName + " " + c.Expert.ApplicationUser.LastName, 
                    CreatAt = c.CreateAt 
                })
                .ToListAsync(cancellationToken); 

            return comments;
        }

        public async Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(commentAcceptDto.Id, cancellationToken);
            if (comment is null) return false;
            comment.IsAccept = commentAcceptDto.IsAccept;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteComment(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(active.Id, cancellationToken);
            if (comment is null) return false;
            comment.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
