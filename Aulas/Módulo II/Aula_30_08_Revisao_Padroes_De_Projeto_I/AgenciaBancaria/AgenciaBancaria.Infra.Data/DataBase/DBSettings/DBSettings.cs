using System.Data.SqlClient;

namespace AgenciaBancaria.Infra.Data.DataBase.DBSettings
{
    public class DBSettings
    {
        private const string _connectionString = @"data source=.\SQLEXPRESS;initial catalog=AgenciaBancariaAline;uid=sa;pwd=123;";

        private static SqlConnection _connection = new SqlConnection();

        public static SqlConnection Conexao()
        {
            _connection.ConnectionString = _connectionString;

            return _connection;
        }
    }
}
