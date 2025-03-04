using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos.ApplicationUserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages;

public class ChangePasswordModel : PageModel
{

    private readonly ICustomerAppService _customerAppServices;
    private readonly IApplicationUserAppService _user;
    public ChangePasswordModel(ICustomerAppService customerAppServices, IApplicationUserAppService user)
    {
        _customerAppServices = customerAppServices;
        _user = user;
    }

    [BindProperty]
    public PasswordDto Password { get; set; }

    public async Task<IActionResult> OnPostChangePassword(CancellationToken cancellationToken)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);
                var customer = await _customerAppServices.GetCustomerById(userId, cancellationToken);
                await _user.Password(customer.ApplictaionUserId, Password);
                TempData["Success"] = "تغییر پسوورد با موفقیت ثبت شد";
                return RedirectToPage("Index");
            }
            return RedirectToPage();

        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = $"خطا({e.Message})";
            return RedirectToPage();
        }

    }
}