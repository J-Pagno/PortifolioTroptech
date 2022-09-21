using System.Data.SqlClient;

namespace AntonioGastos.Infra.Data.Database.Config 
{ 
    public static class DBSettings 
    { 
        private const string _connectionString = @"data source=localhost\SQLEXPRESS;initial catalog=AntonioGastos;uid=sa;pwd=123;";
        private static SqlConnection _connection = new SqlConnection();

        public static SqlConnection Conexao() 
        {
            _connection.ConnectionString = _connectionString;

            return _connection;
        }
    }

}
