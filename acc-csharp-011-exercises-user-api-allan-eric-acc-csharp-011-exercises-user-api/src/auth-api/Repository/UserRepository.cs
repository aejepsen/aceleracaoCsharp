using System.Collections.Generic;
using auth_api.Models;

namespace auth_api.Repository
{
    public class UserRepository
  {
    private readonly AuthContext _context;
    public UserRepository(AuthContext context)
    {
      _context = context;
    }
    public User? GetUser(int id)
    {
      if (id == 0)
      {
        return null;
      }

      return _context.Users.Find(id);
    }
    public IEnumerable<User> GetUsers()
    {
      return _context.Users;
    }
    public User AddUser(User user)
    {
            _ = _context.Users.Add(user);
      _context.SaveChanges();
      return user;
    }
    public User UpdateUser(User user)
    {
            _ = _context.Users.Update(user);
      _context.SaveChanges();
      return user;
    }
    public User DeleteUser(int id)
    {
      var user = _context.Users.Find(id);
            _ = _context.Users.Remove(user);
      _context.SaveChanges();
      return user;
    }
  }
}