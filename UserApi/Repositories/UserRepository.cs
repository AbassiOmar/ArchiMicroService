using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Entities;

namespace UserApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration _configuration)
        {
            this._configuration = _configuration?? throw new ArgumentNullException(nameof(_configuration));
        }
        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            try
            {
                string connectionstring = this._configuration.GetValue<string>("DatabaseSettings:ConnectionString");
                var connection = new NpgsqlConnection(connectionstring);
                var query = "Select * from userdata";
                var users = await connection.QueryAsync<UserVM>(query);
                return users;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
