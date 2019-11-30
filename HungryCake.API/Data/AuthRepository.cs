using System;
using System.Linq;
using System.Threading.Tasks;
using HungryCake.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HungryCake.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

            // user.Grids = await _context.Grids.Where(g => g.UserId == user.Id).ToListAsync();

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // var grid = new Grid(user.Id);
            // await _context.Grids.AddAsync(grid);
            // await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            if(await _context.Users.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }
    }
}