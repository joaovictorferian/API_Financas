using App_Finanças.Infrastructure.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças
{
    public class UserRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public UserRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public Users GetByEmail(string email)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string sql = "SELECT * FROM users WHERE Email = @Email";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Users(                                
                                reader.GetString("name"),
                                reader.GetString("email"),
                                reader.GetString("password_hash"),
                                reader.GetString("phone")
                            );
                        }
                    }
                }
            }
            return null;
        }

        public void AddUser(Users user)
        {
            using(var connection = _dbConnection.GetConnection())
            {
                string sql = @"INSERT INTO users (name, email, password_hash, phone) VALUES (@Name, @Email, @HashPassword, @Phone)";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@HashPassword", user.HashPassword);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);

                    cmd.ExecuteNonQuery();
                }           
            }
            


        }
    }

}
