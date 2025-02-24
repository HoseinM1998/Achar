using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Service
{
    [Authorize(Roles = "Admin")]

    public class RequestModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;
        private readonly ILogger<RequestModel> _logger;

        public RequestModel(IRequestAppService requestAppService, ILogger<RequestModel> logger)
        {
            _requestAppService = requestAppService;
            _logger = logger;
        }

        [BindProperty]
        public List<RequestGetDto?> Requests { get; set; }

        [BindProperty]
        public SoftDeleteDto Delete { get; set; }

        [BindProperty]
        public StatusRequestDto Status { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Requests = await _requestAppService.GetRequests(cancellationToken);
        }

        public async Task<IActionResult> OnPostChangeStatusRequest(CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppService.ChangeRequestStatus(Status, cancellationToken);
                TempData["Success"] = "وضعیت درخواست با موفقیت تغییر یافت.";
                _logger.LogInformation("وضعیت درخواست با موفقیت تغییر یافت. RequestId: {RequestId} در زمان: {Time}", Status.Id, DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در تغییر وضعیت درخواست. RequestId: {RequestId} در زمان: {Time}", Status.Id, DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("Request");
        }

        public async Task<IActionResult> OnPostDeleteRequest(CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppService.DeleteRequest(Delete, cancellationToken);
                TempData["Success"] = "درخواست با موفقیت حذف شد.";
                _logger.LogInformation("درخواست با موفقیت حذف شد. RequestId: {RequestId} در زمان: {Time}", Delete.Id, DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در حذف درخواست. RequestId: {RequestId} در زمان: {Time}", Delete.Id, DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("Request");
        }
    }
}
