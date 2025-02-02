using MySql.Data.MySqlClient;
using System.Data;

namespace GIDDATA
{
    public class MySqlDatabase : IDisposable
    {
        private MySqlConnection _connection;

        public MySqlDatabase(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public MySqlDataReader ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (var command = new MySqlCommand(query, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                return command.ExecuteReader();
            }
        }

        public object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var command = new MySqlCommand(query, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                return command.ExecuteScalar();
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}