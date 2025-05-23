﻿using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Entites;
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


    public class BidModel : PageModel
    {
        private readonly IBidAppService _bidAppService;
        private readonly ILogger<BidModel> _logger;

        public BidModel(IBidAppService bidAppService, ILogger<BidModel> logger)
        {
            _bidAppService = bidAppService;
            _logger = logger;
        }

        [BindProperty]
        public List<GetBidDto> Bids { get; set; }

        [BindProperty]
        public SoftDeleteDto Delete { get; set; }

        [BindProperty]
        public int BidId { get; set; }
        [BindProperty]
        public int ExpertId { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Bids = await _bidAppService.GetBids(cancellationToken);
        }

        public async Task<IActionResult> OnPostCancellBid(CancellationToken cancellationToken)
        {
            try
            {
                await _bidAppService.CancellBid(BidId, ExpertId, cancellationToken);
                TempData["Success"] = "وضعیت پیشنهاد با موفقیت تغییر یافت.";
                _logger.LogInformation("[{Time}] وضعیت پیشنهاد با موفقیت تغییر یافت: {BidId}", DateTime.Now, BidId);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "[{Time}] خطا در تغییر وضعیت پیشنهاد: {BidId}", DateTime.Now, BidId);
            }
            return RedirectToPage("Bid");
        }

        public async Task<IActionResult> OnPostDeleteBid(CancellationToken cancellationToken)
        {
            try
            {
                await _bidAppService.DeleteBid(Delete, cancellationToken);
                TempData["Success"] = "پیشنهاد با موفقیت حذف شد.";
                _logger.LogInformation("[{Time}] پیشنهاد با موفقیت حذف شد: {BidId}", DateTime.Now, Delete.Id);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "[{Time}] خطا در حذف پیشنهاد: {BidId}", DateTime.Now, Delete.Id);
            }
            return RedirectToPage("Bid");
        }
    }
}
