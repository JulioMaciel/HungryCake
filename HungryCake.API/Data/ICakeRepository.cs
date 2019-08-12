using System.Collections.Generic;
using System.Threading.Tasks;
using HungryCake.API.Helpers;
using HungryCake.API.Models;

namespace HungryCake.API.Data
{
    public interface ICakeRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();        
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(string id);
        Task<PagedList<Feed>> GetFeeds(FeedParams feedParams);
        Task<Feed> GetFeed(string id);
    }
}