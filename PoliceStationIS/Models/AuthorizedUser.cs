using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceStationIS.Models
{
    public class AuthorizedUser
    {
        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public int RoleId { get; set; }

        public string Login { get; set; }

        public string RoleName { get; set; }

        public string FullName { get; set; }

        public string PostName { get; set; }
    }
}
