using Npgsql;

namespace PoliceStationIS.Database
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString =
            "Host=localhost;" +
            "Port=5432;" +
            "Database=PoliceStation;" +
            "Username=postgres;" +
            "Password=1234567890;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}