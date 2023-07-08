using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesData.Contracts
{
    public interface IApplicationUser
    {
        string Id { get; set; }
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int UsernameChangeLimit { get; set; }
        byte[]? ProfilePicture { get; set; }
    }
}
