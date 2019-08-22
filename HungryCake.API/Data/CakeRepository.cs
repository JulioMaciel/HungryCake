using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryCake.API.Helpers;
using HungryCake.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HungryCake.API.Data
{
    public class CakeRepository : ICakeRepository
    {
        private readonly DataContext _context;
        public CakeRepository(DataContext _context)
        {
            this._context = _context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUser(int id)
        {
            var query = _context.Users.AsQueryable();

             var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.OrderByDescending(u => u.UserName).AsQueryable();

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                    users = users.OrderByDescending(u => u.Created);
                    break;
                    
                    default:
                    users = users.OrderByDescending(u => u.LastActive);
                    break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        // public async Task<Feed> GetFeed(int id)
        // {
        //     var query = _context.Feeds.AsQueryable();

        //      var feed = await query.FirstOrDefaultAsync(u => u.Id.Equals(id));

        //     return feed;
        // }

        // public async Task<PagedList<Feed>> GetFeeds(FeedParams feedParams)
        // {
        //     var feeds = _context.Feeds.OrderByDescending(u => u.Name).AsQueryable();

        //     if (!string.IsNullOrEmpty(feedParams.OrderBy))
        //     {
        //         switch (feedParams.OrderBy)
        //         {
        //             case "created":
        //             feeds = feeds.OrderByDescending(u => u.Created);
        //             break;
        //         }
        //     }

        //     return await PagedList<Feed>.CreateAsync(feeds, feedParams.PageNumber, feedParams.PageSize);
        // }

    }
}