using MySqlConnector;

namespace MasterClassTestAutomation
{
    public class Dbconnect
    {
        static string connectionString =
            "server=localhost;uid=root;pwd=Password001!;database=autotestdb";

        public static IEnumerable<Dictionary<string, object>> GetTblData(string query)
        {
            var results = new List<Dictionary<string, object>>();
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }
                    results.Add(row);
                }
            }
            catch (Exception) { throw; }

            return results;
        }
    }
}
