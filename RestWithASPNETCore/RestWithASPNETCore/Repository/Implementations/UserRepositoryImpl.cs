using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWithASPNETCore.Model;
using RestWithASPNETCore.Model.Context;

namespace RestWithASPNETCore.Repository.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {
        private MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }


        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }

    }
}
