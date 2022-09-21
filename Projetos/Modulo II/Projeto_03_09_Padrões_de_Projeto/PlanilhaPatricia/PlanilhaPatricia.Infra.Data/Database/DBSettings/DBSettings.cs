using System.Data.SqlClient;

namespace PlanilhaPatricia.Infra.Data.Database.DBSettings
{
    static class DBSettings
    {
        private const string _connectionString = @"data source=.\SQLEXPRESS;initial catalog=PlanilhaPatricia;uid=sa;pwd=123;";

        private static SqlConnection _connection = new SqlConnection();

        public static SqlConnection Conexao()
        {
            _connection.ConnectionString = _connectionString;

            return _connection;
        }
    }
}
