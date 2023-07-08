using Business_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data_Access.Models;
using Data_Access;
namespace Business_Logic
{
    public class AuthService
    {
        public static TokenModel Authenticate(UserModel user)
        {

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
                c.CreateMap<TokenModel, Token>();
                c.CreateMap<User, UserModel>();
                c.CreateMap<Token, TokenModel>();
                
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);
            var result = DataAccessFactory.AuthDataAccess().Authenticate(data);
            var token = mapper.Map<TokenModel>(result);
            return token;
        }
        public static bool IsAuthenticated(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return rs;

        }
        public static bool Logout(string token)
        {
            return DataAccessFactory.AuthDataAccess().Logout(token);
        }

        public static int UserType(string token)
        {
            return DataAccessFactory.AuthDataAccess().GetUserType(token);
        }

        public static bool IsActive(string token)
        {
            return DataAccessFactory.AuthDataAccess().IsActive(token);
        }
    }
}
