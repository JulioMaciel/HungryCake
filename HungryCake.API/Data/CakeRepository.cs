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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<FeedRss> GetFeedRss(int id)
        {
            var query = _context.FeedsRss.AsQueryable();
            var rss = await query.FirstOrDefaultAsync(u => u.Id == id);

            return rss;
        }

        public async Task<FeedRegex> GetFeedHtml(int id)
        {
            var query = _context.FeedsHtml.AsQueryable();
            var feed = await query.FirstOrDefaultAsync(u => u.Id == id);

            return feed;
        }

        public async Task<FeedReddit> GetFeedReddit(int id)
        {
            var query = _context.FeedsReddit.AsQueryable();
            var feed = await query.FirstOrDefaultAsync(u => u.Id == id);

            return feed;
        }

        public async Task<FeedTwitter> GetFeedTwitter(int id)
        {
            var query = _context.FeedsTwitter.AsQueryable();
            var feed = await query.FirstOrDefaultAsync(u => u.Id == id);

            return feed;
        }

        public async Task<Grid> GetGrid(int id)
        {
            var query = _context.Grids.AsQueryable();
            var grid = await query.FirstOrDefaultAsync(u => u.Id == id);

            return grid;
        }

        public async Task<Column> GetColumn(int id)
        {
            var query = _context.Columns.AsQueryable();
            var col = await query.FirstOrDefaultAsync(u => u.Id == id);

            return col;
        }

        // public async Task<IEnumerable<Grid>> LoadUserGrids(int userId)
        // {
        //     var query = _context.Grids.AsQueryable();
        //     var grids = await query.Where(u => u.UserId == userId).ToListAsync();

        //     if (grids.Any())
        //         return grids;

        //     // var newGrid = new Grid {
        //     //     UserId = userId
        //     // };

        //     // await _context.SaveChangesAsync();

        //     // var newCol = new Column{
        //     //     Grid = await _context.Grids.LastOrDefaultAsync(),
        //     // };

        //     return await query.Where(u => u.UserId == userId).ToListAsync();            
        // }

        public async Task<IEnumerable<FeedRss>> GetRssList()
        {
            var rssList = await _context.FeedsRss.ToListAsync();
            return rssList;
        }

        public async Task<IEnumerable<Grid>> GetUserGrids(int userId)
        {
            var userGrids = await _context.Grids.Where(g => g.UserId == userId).ToListAsync();
            return userGrids;
        }

        public async Task<IEnumerable<Column>> GetColumnsFromGrid(int gridId)
        {
            var gridCols = await _context.Columns.Where(c => c.GridId == gridId).ToListAsync();
            return gridCols;
        }
    }
}