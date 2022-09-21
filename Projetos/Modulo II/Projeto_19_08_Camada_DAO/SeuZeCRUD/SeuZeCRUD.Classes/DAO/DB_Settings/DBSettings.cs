using System;
using System.Data.SqlClient;

namespace SeuZeCRUD.Classes.DAO.DB_Settings
{
    public class DBSettings
    {
        private const string _connectionString =
            @"data source=.\SQLEXPRESS;initial catalog=MercadoZe;uid=sa;pwd=123;";

        public static string ConnectionString => _connectionString;

        public static SqlConnection Conexao()
        {
            var conexao = new SqlConnection(ConnectionString);

            return conexao;
        }
    }
}
