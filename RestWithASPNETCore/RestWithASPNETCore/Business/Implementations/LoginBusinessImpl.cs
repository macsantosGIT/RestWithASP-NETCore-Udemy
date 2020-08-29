using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using RestWithASPNETCore.Data.VO;
using RestWithASPNETCore.Model;
using RestWithASPNETCore.Repository;
using RestWithASPNETCore.Repository.Generic;
using RestWithASPNETCore.Security.Configuration;

namespace RestWithASPNETCore.Business.Implementations
{
    public class LoginBusinessImpl : ILoginBusiness
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenCofiguration _tokenCofigurarion;

        public LoginBusinessImpl(IUserRepository repository, SigningConfigurations signingConfigurations, TokenCofiguration tokenCofigurarion)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenCofigurarion = tokenCofigurarion;
        }

        public object FindByLogin(UserVO user)
        {
            bool credentialsIsValid = false;
            if (user != null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var baseUser = _repository.FindByLogin(user.Login);
                credentialsIsValid = (baseUser != null && user.Login == baseUser.Login && user.AccessKey == baseUser.AccessKey);
            }
            if (credentialsIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(user.Login, "Login"),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
                        }
                    );
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromMinutes(_tokenCofigurarion.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token);
            }
            else
            {
                return ExceptionObjejct();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenCofigurarion.Issuer,
                Audience = _tokenCofigurarion.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity, 
                NotBefore = createDate, 
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object ExceptionObjejct()
        {
            return new
            {
                autenticated = false,
                message = "Failed to Authenticate"
            };
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
