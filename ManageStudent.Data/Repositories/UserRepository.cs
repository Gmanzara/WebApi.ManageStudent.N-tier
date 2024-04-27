using ManageStudent.Core.Models;
using ManageStudent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ManageStudentDbContext dbContext) : base(dbContext)
        {
        }
        private ManageStudentDbContext ManageStudentDbContext 
        {
            get { return dbContext as ManageStudentDbContext; }
        }
        private readonly ManageStudentDbContext _dbManageStudentDbContext;
        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            
            var user  = await ManageStudentDbContext.Users.SingleOrDefaultAsync(x => x.UserName == username);
        
            if (user == null) return null;
            if(VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt)) return null;
            return user;
        }

        public static bool VerifyPasswordHash(string password, byte[] storeHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("values connot be empty or whitespace only string.", "password");
            if (storedSalt == null) throw new ArgumentNullException("Invalid lengh of password salt(128 bytes expected).", "passwordSalt");
            if (storeHash == null) throw new ArgumentNullException("Invalid lengh of password hash(64 bytes expected.", "passwordHash");
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != storedSalt[i])
                        return false;
                }
            }
            return true;
        }
        public async Task<User> Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password is required");
            var resultUser = await ManageStudentDbContext.Users.AnyAsync(x => x.UserName == user.UserName);
            if (resultUser)
                throw new Exception("Username \"" + user.UserName + "\" is already taken");
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await ManageStudentDbContext.Users.AddAsync(user);
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("value cannot be empty");
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public void Delete(int id)
        {
            var user = ManageStudentDbContext.Users.Find(id);
            if (user != null)
            {
                ManageStudentDbContext.Users.Remove(user);
            }
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await ManageStudentDbContext.Users
                    .ToListAsync();

        }

        public async Task<User> GetWithUserByIdAsync(int id)
        {
            return await ManageStudentDbContext.Users
              .Where(user => user.Id == id)
              .FirstOrDefaultAsync();
        }

        public void Update(User user, string password = null)
        {
            var userr = ManageStudentDbContext.Users.Find(user.Id);
            if (userr == null)
                throw new Exception("User not found");
            if (user.UserName != userr.UserName)
            {
                if (ManageStudentDbContext.Users.Any(x => x.UserName == user.UserName))
                    throw new Exception("Username \"" + user.UserName + "\" is already taken");
            }

            user.FirstName = userr.FirstName;
            user.LastName = userr.LastName;
            user.UserName = userr.UserName;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            ManageStudentDbContext.Users.Update(user);
        }
    }
}
