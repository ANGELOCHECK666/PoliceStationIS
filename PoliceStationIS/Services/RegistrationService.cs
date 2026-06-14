using System;
using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Models;
using System.Security.Cryptography;
using System.Text;

namespace PoliceStationIS.Services
{
    public class RegistrationService
    {
        public static void Register(
            RegistrationData data)
        {
            using (var connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (var transaction =
                       connection.BeginTransaction())
                {
                    try
                    {
                        int sexId =
                            GetSexId(
                                connection,
                                data.Gender);

                        int departmentId =
                            GetDepartmentId(
                                connection,
                                data.Department);

                        int postId =
                            GetPostId(
                                connection,
                                data.Position);

                        int rankId =
                            GetRankId(
                                connection,
                                data.Rank);

                        int passportIssuanceId =
                            GetPassportIssuanceId(
                                connection,
                                data.IssuedBy);

                        int employeeId =
                            InsertEmployee(
                                connection,
                                data,
                                sexId,
                                departmentId,
                                postId,
                                rankId,
                                passportIssuanceId);

                        InsertUser(
                            connection,
                            employeeId,
                            data);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        private static int GetSexId(
    NpgsqlConnection connection,
    string sexName)
        {
            string query =
                @"SELECT sex_id
                  FROM sex
                  WHERE sex_name = @name";

            using (var command =
                   new NpgsqlCommand(
                       query,
                       connection))
            {
                command.Parameters.AddWithValue(
                    "@name",
                    sexName);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private static int GetDepartmentId(
            NpgsqlConnection connection,
            string departmentName)
        {
            string query =
                @"SELECT department_id
                  FROM department
                  WHERE department_name = @name";

            using (var command =
                   new NpgsqlCommand(
                       query,
                       connection))
            {
                command.Parameters.AddWithValue(
                    "@name",
                    departmentName);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private static int GetPostId(
            NpgsqlConnection connection,
            string postName)
        {
            string query =
                @"SELECT post_id
                  FROM post
                  WHERE post_name = @name";

            using (var command =
                   new NpgsqlCommand(
                       query,
                       connection))
            {
                command.Parameters.AddWithValue(
                    "@name",
                    postName);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private static int GetRankId(
            NpgsqlConnection connection,
            string rankName)
        {
            string query =
                @"SELECT rank_id
                  FROM rank_
                  WHERE rank_name = @name";

            using (var command =
                   new NpgsqlCommand(
                       query,
                       connection))
            {
                command.Parameters.AddWithValue(
                    "@name",
                    rankName);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private static int GetPassportIssuanceId(
            NpgsqlConnection connection,
            string issuanceName)
        {
            string query =
                @"SELECT passport_issuance_id
                  FROM passport_issuance
                  WHERE passport_issuance_name = @name";

            using (var command =
                   new NpgsqlCommand(
                       query,
                       connection))
            {
                command.Parameters.AddWithValue(
                    "@name",
                    issuanceName);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }
        private static int InsertEmployee(
    NpgsqlConnection connection,
    RegistrationData data,
    int sexId,
    int departmentId,
    int postId,
    int rankId,
    int passportIssuanceId)
        {
            string query =
                @"
        INSERT INTO Employee
(
    sex_id,
    passport_issuance_id,
    department_id,
    post_id,
    rank_id,
    employment_status_id,

    passport_series,
    passport_number,

            last_name,
            name_,
            middle_name,

            phone_number,

            date_of_issue,
            date_of_birth,

            registration_address,
            residential_address
        )
        VALUES
        (
    @sex_id,
    @passport_issuance_id,
    @department_id,
    @post_id,
    @rank_id,
    @employment_status_id,

    @passport_series,
            @passport_number,

            @last_name,
            @name_,
            @middle_name,

            @phone_number,

            @date_of_issue,
            @date_of_birth,

            @registration_address,
            @residential_address
        )
        RETURNING employee_id;
        ";

            using (var command =
                   new NpgsqlCommand(
                       query,
                       connection))
            {
                command.Parameters.AddWithValue(
                    "@sex_id",
                    sexId);

                command.Parameters.AddWithValue(
                    "@passport_issuance_id",
                    passportIssuanceId);

                command.Parameters.AddWithValue(
                    "@department_id",
                    departmentId);

                command.Parameters.AddWithValue(
                    "@post_id",
                    postId);

                command.Parameters.AddWithValue(
                    "@rank_id",
                    rankId);
                command.Parameters.AddWithValue(
    "@employment_status_id",
    1);

                command.Parameters.AddWithValue(
                    "@passport_series",
                    data.PassportSeries);

                command.Parameters.AddWithValue(
                    "@passport_number",
                    data.PassportNumber);

                command.Parameters.AddWithValue(
                    "@last_name",
                    data.LastName);

                command.Parameters.AddWithValue(
                    "@name_",
                    data.FirstName);

                command.Parameters.AddWithValue(
                    "@middle_name",
                    string.IsNullOrWhiteSpace(
                        data.MiddleName)
                        ? (object)DBNull.Value
                        : data.MiddleName);

                command.Parameters.AddWithValue(
                    "@phone_number",
                    data.Phone);

                command.Parameters.AddWithValue(
                    "@date_of_issue",
                    DateTime.ParseExact(
                        data.IssueDate,
                        "dd.MM.yyyy",
                        null));

                command.Parameters.AddWithValue(
                    "@date_of_birth",
                    DateTime.ParseExact(
                        data.BirthDate,
                        "dd.MM.yyyy",
                        null));

                command.Parameters.AddWithValue(
                    "@registration_address",
                    data.RegistrationAddress);

                command.Parameters.AddWithValue(
                    "@residential_address",
                    data.ResidentialAddress);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }
        private static void InsertUser(
    NpgsqlConnection connection,
    int employeeId,
    RegistrationData data)
        {
            string passwordHash =
                HashPassword(
                    data.Password);

            string query =
                @"
        INSERT INTO App_user
        (
            employee_id,
            user_role_id,
            login_,
            email,
            password_hash
        )
        VALUES
        (
            @employee_id,
            @user_role_id,
            @login_,
            @email,
            @password_hash
        );
        ";

            using (var command =
                   new NpgsqlCommand(
                       query,
                       connection))
            {
                command.Parameters.AddWithValue(
                    "@employee_id",
                    employeeId);

                command.Parameters.AddWithValue(
                    "@user_role_id",
                    11);

                command.Parameters.AddWithValue(
                    "@login_",
                    data.Login);

                command.Parameters.AddWithValue(
                    "@email",
                    data.Email);

                command.Parameters.AddWithValue(
                    "@password_hash",
                    passwordHash);

                command.ExecuteNonQuery();
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