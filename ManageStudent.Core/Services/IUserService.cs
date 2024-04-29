using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Create(User user);
        void Update(User user, string password = null);
        void Delete(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
    }
}
