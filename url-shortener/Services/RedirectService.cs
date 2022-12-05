using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Services
{

/*
            Task<URLRedirect[]> GetRedirectsForUserAsync(IdentityUser theUser);
            Task<bool> AddRedirectAsync(TodoItem newItem);
            Task<URLRedirect> VisitRedirectAsync(string id);
*/
    public class RedirectService : IRedirectService
    {
        private readonly ApplicationDbContext _context;
        public RedirectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<URLRedirect[]> GetRedirectsForUserAsync(IdentityUser theUser)
        {
            return await _context.Redirects
                .Where(x => x.UserId == theUser.Id)
                .ToArrayAsync();
        }
        public async Task<bool> RedirectExists(string Id)
        {
            var theRedirect=await _context.Redirects.Where(x => x.Id==Id).SingleOrDefaultAsync();
            return theRedirect!=null;
        }
        public async Task<bool> AddRedirectAsync(URLRedirect newItem)
        {

            _context.Redirects.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<URLRedirect> VisitRedirectAsync(string Id) {
            URLRedirect item = await _context.Redirects
                .Where(x => x.Id == Id)
                .SingleOrDefaultAsync();
            if (item == null) return null;
            item.NumVisits++;
            var saveResult = await _context.SaveChangesAsync();
            return item; 
        }
    }
}
