using E_commerce.Interfaces;
using E_commerce.Models;

namespace E_commerce.Services
{
    public class UserService : RepoistoryPattern<User> , IUser
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
