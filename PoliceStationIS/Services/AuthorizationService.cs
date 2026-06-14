using System;
using System.Security.Cryptography;
using System.Text;
using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Models;

namespace PoliceStationIS.Services
{
    public class AuthorizationService
    {
        public static AuthorizedUser Login(
            string login,
            string password)
        {
            string passwordHash =
                HashPassword(password);

            using (var connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
    u.user_id,
    u.employee_id,
    u.user_role_id,
    u.login_,
    r.user_role_name,

    e.last_name,
    e.name_,
    e.middle_name,

    p.post_name

FROM app_user u

JOIN user_role r
    ON r.user_role_id = u.user_role_id

JOIN employee e
    ON e.employee_id = u.employee_id

JOIN post p
    ON p.post_id = e.post_id
                    WHERE
                        u.login_ = @login
                        AND u.password_hash = @password_hash
                        AND u.is_active = TRUE;
                    ";

                using (var command =
                       new NpgsqlCommand(
                           query,
                           connection))
                {
                    command.Parameters.AddWithValue(
                        "@login",
                        login);

                    command.Parameters.AddWithValue(
                        "@password_hash",
                        passwordHash);

                    using (var reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        return new AuthorizedUser
                        {
                            UserId =
        Convert.ToInt32(
            reader["user_id"]),

                            EmployeeId =
        Convert.ToInt32(
            reader["employee_id"]),

                            RoleId =
        Convert.ToInt32(
            reader["user_role_id"]),

                            Login =
        reader["login_"]
            .ToString(),

                            RoleName =
        reader["user_role_name"]
            .ToString(),

                            FullName =
        $"{reader["last_name"]} " +
        $"{reader["name_"]} " +
        $"{reader["middle_name"]}",

                            PostName =
        reader["post_name"]
            .ToString()
                        };
                    }
                }
            }
        }

        private static string HashPassword(
            string password)
        {
            using (SHA256 sha256 =
                   SHA256.Create())
            {
                byte[] bytes =
                    Encoding.UTF8.GetBytes(
                        password);

                byte[] hash =
                    sha256.ComputeHash(
                        bytes);

                StringBuilder builder =
                    new StringBuilder();

                foreach (byte b in hash)
                {
                    builder.Append(
                        b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}