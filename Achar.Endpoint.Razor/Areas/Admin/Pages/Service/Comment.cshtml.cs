using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Service
{
    public class CommentModel : PageModel
    {
        private readonly ICommentAppService _commentAppService;
        private readonly ILogger<CommentModel> _logger;

        public CommentModel(ICommentAppService commentAppService, ILogger<CommentModel> logger)
        {
            _commentAppService = commentAppService;
            _logger = logger;
        }

        [BindProperty]
        public List<AllCommentDto?> Comments { get; set; }

        [BindProperty]
        public SoftDeleteDto Delete { get; set; }

        [BindProperty]
        public CommentAcceptDto Status { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Comments = await _commentAppService.GetAllComment(cancellationToken);
        }

        public async Task<IActionResult> OnPostActiveComment(CancellationToken cancellationToken)
        {
            try
            {
                await _commentAppService.AcceptComment(Status, cancellationToken);
                TempData["Success"] = "وضعیت نظر با موفقیت تغییر یافت.";
                _logger.LogInformation("وضعیت نظر با موفقیت تغییر یافت. CommentId: {CommentId} در زمان: {Time}", Status.Id, DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در تغییر وضعیت نظر. CommentId: {CommentId} در زمان: {Time}", Status.Id, DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("Comment");
        }

        public async Task<IActionResult> OnPostDeleteComment(CancellationToken cancellationToken)
        {
            try
            {
                await _commentAppService.DeleteComment(Delete, cancellationToken);
                TempData["Success"] = "نظر با موفقیت حذف شد.";
                _logger.LogInformation("نظر با موفقیت حذف شد. CommentId: {CommentId} در زمان: {Time}", Delete.Id, DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در حذف نظر. CommentId: {CommentId} در زمان: {Time}", Delete.Id, DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("Comment");
        }
    }
}
