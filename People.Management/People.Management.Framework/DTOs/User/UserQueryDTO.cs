using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Management.Framework.DTOs.User
{
    public class UserQueryDTO
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
