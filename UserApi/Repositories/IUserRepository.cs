using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Entities;

namespace UserApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserVM>> GetUsers();
    }
}
