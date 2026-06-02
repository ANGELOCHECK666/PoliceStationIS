using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceStationIS.Models
{
    public class User
    {
        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public string Login { get; set; }

        public string Role { get; set; }

        public string Post { get; set; }
    }
}
