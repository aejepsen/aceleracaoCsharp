using Microsoft.Extensions.Caching.Memory;
using auth_api.Repository;
using auth_api.Models;
using System.Collections.Generic;
using System;

namespace auth_api.Store
{
  public class UserCachingStore
  {
    private readonly IMemoryCache _memoryCache;
    private readonly UserRepository _userRepository;

    public UserCachingStore(IMemoryCache memoryCache, UserRepository userRepository)
    {
      _memoryCache = memoryCache;
      _userRepository = userRepository;
    }
    public IEnumerable<User> GetUsers()
    {
      throw new NotImplementedException();
    }

    public User Get(int userid)
    {
      throw new NotImplementedException();
    }

    private static string GetKey(string key)
    {
      throw new NotImplementedException();
    }
  }
}