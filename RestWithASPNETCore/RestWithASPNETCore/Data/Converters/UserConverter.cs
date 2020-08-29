using RestWithASPNETCore.Data.Converter;
using RestWithASPNETCore.Data.VO;
using RestWithASPNETCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETCore.Data.Converters
{
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO>
    {
        public User Parse(UserVO origin)
        {
            if (origin == null) return new User();
            return new User
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public UserVO Parse(User origin)
        {
            if (origin == null) return new UserVO();
            return new UserVO
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public List<User> ParseList(List<UserVO> origins)
        {
            if (origins == null) return new List<User>();
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<UserVO> ParseList(List<User> origins)
        {
            if (origins == null) return new List<UserVO>();
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
