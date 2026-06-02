using Npgsql;

namespace PoliceStationIS.Database
{
    public static class DatabaseTester
    {
        public static bool TestConnection()
        {
            try
            {
                using (var connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}