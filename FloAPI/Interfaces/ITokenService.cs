using FloAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloAPI.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}
