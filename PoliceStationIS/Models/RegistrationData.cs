using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceStationIS.Models
{
    public class RegistrationData
    {
        // Личные данные

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string BirthDate { get; set; }

        public string Gender { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Rank { get; set; }


        // Паспорт

        public string PassportSeries { get; set; }

        public string PassportNumber { get; set; }

        public string DepartmentCode { get; set; }

        public string IssuedBy { get; set; }

        public string IssueDate { get; set; }

        public string RegistrationAddress { get; set; }


        // Контакты

        public string Phone { get; set; }

        public string ResidentialAddress { get; set; }


        // Аккаунт

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
