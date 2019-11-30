using System.Collections.Generic;
using System.Threading.Tasks;
using HungryCake.API.Dtos;
using HungryCake.API.Helpers;
using HungryCake.API.Models;

namespace HungryCake.API.Data
{
    public interface ICakeRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();        
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int userId);
        Task<FeedRss> GetFeedRss(int rssId);
        Task<IEnumerable<FeedRss>> GetRssList();
        Task<Grid> GetGrid(int gridId);
        Task<Column> GetColumn(int columnId);
        Task<IEnumerable<Column>> GetColumnsFromGrid(int gridId);
        Task<IEnumerable<Grid>> GetUserGrids(int userId);
    }
}