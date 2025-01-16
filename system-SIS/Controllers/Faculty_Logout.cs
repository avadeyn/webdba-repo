using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;

public class AccountController : Controller
{
    // Faculty Logout action
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Faculty_Logout()
    {
        // Sign out the user by clearing the session
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // Redirect to the home page after logout
        return RedirectToAction("Index", "Home");
    }
}
