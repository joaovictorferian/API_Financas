using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace App_Finanças.Infrastructure.Database
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["FinancasDB"].ConnectionString;
            
            if(string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Connection string 'FinancasDB' não encontrada no App.config!");
            }
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                var connection = new MySqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch (MySqlException exception)
            {
                throw new Exception($"Erro ao conectar no banco de dados: {exception.Message}", exception);
            }
        }

        public bool TestConnection()
        {
            try
            {
                using(var connection = GetConnection())
                {
                    Console.WriteLine("Conexão com MySQL estabelecida com sucesso!");
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Erro na conexão: {exception.Message}");
                return false;
            }
        }
    }

}
