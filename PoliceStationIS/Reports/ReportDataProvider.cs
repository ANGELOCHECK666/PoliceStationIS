using System;
using System.Collections.Generic;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Reports
{
    public class ReportDataProvider
    {
        private NpgsqlConnection GetConnection()
        {
            return DatabaseConnection.GetConnection();
        }

        public List<List<string>> GetReportData(
    int reportTypeId,
    DateTime dateFrom,
    DateTime dateTo,
    List<string> options)
        {
            switch (reportTypeId)
            {
                case 1:
                    return GetEmployeeList(
                        dateFrom,
                        dateTo,
                        options);

                case 2:
                    return GetVacationEmployees(
                        dateFrom,
                        dateTo,
                        options);

                case 3:
                    return GetSickLeaveEmployees(
                        dateFrom,
                        dateTo,
                        options);

                case 4:
                    return GetPersonnelChanges(
                        dateFrom,
                        dateTo,
                        options);

                case 5:
                    return GetNewEmployees(
                        dateFrom,
                        dateTo,
                        options);

                case 6:
                    return GetDismissedEmployees(
                        dateFrom,
                        dateTo,
                        options);

                default:
                    return new List<List<string>>();
            }

        }

        private List<List<string>> GetEmployeeList(
    DateTime dateFrom,
    DateTime dateTo,
    List<string> options)
        {
            List<List<string>> rows =
                new List<List<string>>();

            using (NpgsqlConnection connection =
                GetConnection())
            {
                connection.Open();

                List<string> selectColumns =
    new List<string>();

                selectColumns.Add(
                    "e.Last_name");

                selectColumns.Add(
                    "e.Name_");

                selectColumns.Add(
                    "e.Middle_name");

                if (options.Contains(
    "Добавить должность"))
                {
                    selectColumns.Add(
                        "p.Post_name");
                }

                if (options.Contains(
                    "Добавить подразделение"))
                {
                    selectColumns.Add(
                        "d.Department_name");
                }

                if (options.Contains(
                    "Добавить дату приема"))
                {
                    selectColumns.Add(
                        "e.Service_start_date");
                }

                string query =
$@"
SELECT
    {string.Join(", ", selectColumns)}
FROM Employee e
JOIN Post p
    ON p.Post_id = e.Post_id
JOIN Department d
    ON d.Department_id = e.Department_id
WHERE
    e.Service_start_date
BETWEEN
    @dateFrom
AND
    @dateTo
ORDER BY
    e.Last_name,
    e.Name_;
";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@dateFrom",
                        dateFrom);

                    command.Parameters.AddWithValue(
                        "@dateTo",
                        dateTo);

                    {
                        using (NpgsqlDataReader reader =
    command.ExecuteReader())
                        {
                            rows =
                                ReadReportRows(reader);
                        }
                    }
                }

                return rows;
            }
        }

        private List<List<string>> GetPersonnelChanges(
    DateTime dateFrom,
    DateTime dateTo,
    List<string> options)
        {
            List<List<string>> rows =
    new List<List<string>>();

            List<string> selectColumns =
                new List<string>();

            selectColumns.Add("e.Last_name");
            selectColumns.Add("e.Name_");
            selectColumns.Add("e.Middle_name");

            if (options.Contains(
    "Добавить старую должность"))
            {
                selectColumns.Add(
                    "oldPost.Post_name");
            }

            if (options.Contains(
                "Добавить новую должность"))
            {
                selectColumns.Add(
                    "newPost.Post_name");
            }

            if (options.Contains(
                "Добавить дату изменения"))
            {
                selectColumns.Add(
                    "pc.Change_date");
            }

            string query =
$@"
SELECT

{string.Join(", ", selectColumns)}

FROM Personnel_change pc

INNER JOIN Employee e
ON e.Employee_id =
pc.Employee_id

INNER JOIN Post oldPost
ON oldPost.Post_id =
pc.Old_post_id

INNER JOIN Post newPost
ON newPost.Post_id =
pc.New_post_id

WHERE

pc.Change_date

BETWEEN

@dateFrom

AND

@dateTo

ORDER BY

pc.Change_date DESC;
";

            using (NpgsqlConnection connection =
    GetConnection())
            {
                connection.Open();

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@dateFrom",
                        dateFrom.Date);

                    command.Parameters.AddWithValue(
                        "@dateTo",
                        dateTo.Date);

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        rows =
        ReadReportRows(reader);
                    }
                    return rows;
                }
            }
        }

        private List<List<string>> GetVacationEmployees(
    DateTime dateFrom,
    DateTime dateTo,
    List<string> options)
        {
            List<List<string>> rows =
    new List<List<string>>();

            List<string> selectColumns =
                new List<string>();

            selectColumns.Add("e.Last_name");
            selectColumns.Add("e.Name_");
            selectColumns.Add("e.Middle_name");

            if (options.Contains("Добавить подразделение"))
            {
                selectColumns.Add("d.Department_name");
            }

            if (options.Contains("Добавить количество дней"))
            {
                selectColumns.Add(
                    "(ev.End_date - ev.Start_date + 1)");
            }

            if (options.Contains("Добавить дату выхода"))
            {
                selectColumns.Add("ev.End_date");
            }

            string query =
$@"
SELECT

{string.Join(", ", selectColumns)}

FROM Employee_vacation ev

INNER JOIN Employee e
ON e.Employee_id =
ev.Employee_id

INNER JOIN Department d
ON d.Department_id =
e.Department_id

INNER JOIN Vacation_type vt
ON vt.Vacation_type_id =
ev.Vacation_type_id

WHERE

ev.Start_date

BETWEEN

@dateFrom

AND

@dateTo

ORDER BY

ev.Start_date,
e.Last_name,
e.Name_;
";

            using (NpgsqlConnection connection =
    GetConnection())
            {
                connection.Open();

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@dateFrom",
                        dateFrom.Date);

                    command.Parameters.AddWithValue(
                        "@dateTo",
                        dateTo.Date);

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        rows =
                            ReadReportRows(reader);
                    }
                }
            }

            return rows;
        }

        private List<List<string>> GetSickLeaveEmployees(
    DateTime dateFrom,
    DateTime dateTo,
    List<string> options)
        {
            List<List<string>> rows =
    new List<List<string>>();

            List<string> selectColumns =
                new List<string>();

            selectColumns.Add("e.Last_name");
            selectColumns.Add("e.Name_");
            selectColumns.Add("e.Middle_name");

            if (options.Contains("Добавить подразделение"))
            {
                selectColumns.Add("d.Department_name");
            }

            if (options.Contains("Добавить должность"))
            {
                selectColumns.Add("p.Post_name");
            }

            if (options.Contains("Добавить период больничного"))
            {
                selectColumns.Add(
                    "TO_CHAR(esl.Start_date, 'DD.MM.YYYY') || ' - ' || TO_CHAR(esl.End_date, 'DD.MM.YYYY')");
            }

            string query =
$@"
SELECT

{string.Join(", ", selectColumns)}

FROM Employee_sick_leave esl

INNER JOIN Employee e
ON e.Employee_id =
esl.Employee_id

INNER JOIN Department d
ON d.Department_id =
e.Department_id

INNER JOIN Post p
ON p.Post_id =
e.Post_id

WHERE

esl.Start_date

BETWEEN

@dateFrom

AND

@dateTo

ORDER BY

esl.Start_date,
e.Last_name,
e.Name_;
";

            using (NpgsqlConnection connection =
    GetConnection())
            {
                connection.Open();

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@dateFrom",
                        dateFrom.Date);

                    command.Parameters.AddWithValue(
                        "@dateTo",
                        dateTo.Date);

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        rows =
                            ReadReportRows(reader);
                    }
                }
            }

            return rows;
        }

        private List<List<string>> GetDismissedEmployees(
    DateTime dateFrom,
    DateTime dateTo,
    List<string> options)
        {
            List<List<string>> rows =
    new List<List<string>>();

            List<string> selectColumns =
                new List<string>();

            selectColumns.Add("e.Last_name");
            selectColumns.Add("e.Name_");
            selectColumns.Add("e.Middle_name");

            if (options.Contains("Добавить подразделение"))
            {
                selectColumns.Add("d.Department_name");
            }

            if (options.Contains("Добавить должность"))
            {
                selectColumns.Add("p.Post_name");
            }

            if (options.Contains("Добавить дату увольнения"))
            {
                selectColumns.Add("e.Service_end_date");
            }

            string query =
$@"
SELECT

{string.Join(", ", selectColumns)}

FROM Employee e

INNER JOIN Department d
ON d.Department_id =
e.Department_id

INNER JOIN Post p
ON p.Post_id =
e.Post_id

INNER JOIN Employment_status es
ON es.Employment_status_id =
e.Employment_status_id

WHERE

es.Employment_status_name = 'Уволен'

AND

e.Service_end_date
BETWEEN
@dateFrom
AND
@dateTo

ORDER BY

e.Service_end_date DESC,
e.Last_name,
e.Name_;
";

            using (NpgsqlConnection connection =
    GetConnection())
            {
                connection.Open();

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@dateFrom",
                        dateFrom.Date);

                    command.Parameters.AddWithValue(
                        "@dateTo",
                        dateTo.Date);

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        rows =
                            ReadReportRows(reader);
                    }
                }
            }

            return rows;
        }

        private List<List<string>> GetNewEmployees(
    DateTime dateFrom,
    DateTime dateTo,
    List<string> options)
        {
            List<List<string>> rows =
    new List<List<string>>();

            List<string> selectColumns =
                new List<string>();

            selectColumns.Add("e.Last_name");
            selectColumns.Add("e.Name_");
            selectColumns.Add("e.Middle_name");

            if (options.Contains("Добавить подразделение"))
            {
                selectColumns.Add("d.Department_name");
            }

            if (options.Contains("Добавить должность"))
            {
                selectColumns.Add("p.Post_name");
            }

            if (options.Contains("Добавить дату приема"))
            {
                selectColumns.Add("e.Service_start_date");
            }

            string query =
$@"
SELECT
    {string.Join(", ", selectColumns)}
FROM Employee e

INNER JOIN Post p
    ON p.Post_id = e.Post_id

INNER JOIN Department d
    ON d.Department_id = e.Department_id

WHERE
    e.Service_start_date
BETWEEN
    @dateFrom
AND
    @dateTo

ORDER BY
    e.Service_start_date DESC,
    e.Last_name,
    e.Name_;
";

            using (NpgsqlConnection connection =
    GetConnection())
            {
                connection.Open();

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@dateFrom",
                        dateFrom.Date);

                    command.Parameters.AddWithValue(
                        "@dateTo",
                        dateTo.Date);

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        rows =
                            ReadReportRows(reader);
                    }
                }
            }

            return rows;
        }

        private List<List<string>> ReadReportRows(
    NpgsqlDataReader reader)
        {
            List<List<string>> rows =
                new List<List<string>>();

            int number = 1;

            while (reader.Read())
            {
                List<string> row =
                    new List<string>();

                row.Add(number.ToString());

                string fio =
                    reader.GetString(0) +
                    " " +
                    reader.GetString(1);

                if (!reader.IsDBNull(2))
                {
                    fio +=
                        " " +
                        reader.GetString(2);
                }

                row.Add(fio);

                for (int columnIndex = 3;
                     columnIndex < reader.FieldCount;
                     columnIndex++)
                {
                    if (reader.IsDBNull(columnIndex))
                    {
                        row.Add("");
                        continue;
                    }

                    object value =
                        reader.GetValue(columnIndex);

                    if (value is DateTime date)
                    {
                        row.Add(
                            date.ToString("dd.MM.yyyy"));
                    }
                    else
                    {
                        row.Add(
                            value.ToString());
                    }
                }

                rows.Add(row);

                number++;
            }

            return rows;
        }

        private List<string> BuildRow(
    params string[] values)
        {
            return new List<string>(values);
        }
    }
}
