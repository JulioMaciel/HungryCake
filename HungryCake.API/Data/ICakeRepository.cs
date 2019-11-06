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
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<FeedRss> GetFeedRss(int id);
        Task<IEnumerable<FeedRss>> GetRssList();
    }
}