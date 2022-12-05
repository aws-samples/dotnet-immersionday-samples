using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class RedirectAdminController : Controller
    {
        private readonly IRedirectService _redirectService;
        private readonly UserManager<IdentityUser> _userManager;
        public RedirectAdminController(IRedirectService redirectService, UserManager<IdentityUser> userManager)
        {
            _redirectService = redirectService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(){
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            var redirects = await _redirectService.GetRedirectsForUserAsync(currentUser);
            var model = new RedirectsViewModel() {
                Redirects = redirects
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRedirect(URLRedirect newRedirect)
        {
            if (!ModelState.IsValid) {
                return RedirectToAction("Index");
            }
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            newRedirect.UserId=currentUser.Id;
            var successful = await _redirectService.AddRedirectAsync(newRedirect);
            if (!successful) {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }


    }
}
