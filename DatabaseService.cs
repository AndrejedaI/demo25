using MySql.Data.MySqlClient;

namespace DemExTest
{
    public class DatabaseService
    {
        private string _connStr;
        public DatabaseService(string connStr) 
        {
            _connStr = connStr;
        }

        public List<T> ExecuteQuery<T>(string query, Func<MySqlDataReader, T> map, Dictionary<string, object>? parameters = null)
        {

            List<T> result = new();
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = new MySqlCommand(query, conn);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(map(reader));
            }

            return result;
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object>? parameters = null)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = new MySqlCommand(query, conn);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            return cmd.ExecuteNonQuery();
        }
    }
}
