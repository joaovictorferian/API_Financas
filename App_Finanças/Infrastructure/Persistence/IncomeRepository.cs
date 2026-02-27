using App_Finanças.Application.Services;
using App_Finanças.Infrastructure.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças.Infrastructure.Persistence
{

    public class IncomeRepository
    {
        private readonly DatabaseConnection _dbConnection;
        public IncomeRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void ReadIncomes(Income income)
        {
            var readList = new List<Income>();
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    string sql = "SELECT * FROM incomes";
                    using (var cmd = new MySqlCommand(sql, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Incomes = new Income
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Category = reader.GetString(reader.GetOrdinal("category")),
                                Value = reader.GetDouble(reader.GetOrdinal("value")),
                                Date = reader.GetDateTime(reader.GetOrdinal("date"))
                            };
                            readList.Add(Incomes);
                        }
 
                    }


                }
            }

        }
        public void SaveIncome(Income income)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    string sql = @"INSERT INTO incomes (Title, Description, Category, Value, Date) 
                               VALUES (@Title, @Description, @Category, @Value, @Date)";

                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", income.Title);
                        cmd.Parameters.AddWithValue("@Description", income.Description);
                        cmd.Parameters.AddWithValue("@Category", income.Category);
                        cmd.Parameters.AddWithValue("@Value", income.Value);
                        cmd.Parameters.AddWithValue("@Date", income.Date);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao salvar o income: {ex.Message} ", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao salvar o income: {ex.Message} ", ex);
            }
        }

        public void UpdateIncome(
            int id,
            string title = null,
            string description = null,
            string category = null,
            double? value = null,
            DateTime? date = null
            )
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;

                    var setParts = new List<string>();

                    if (title != null)
                    {
                        setParts.Add("title = @Title");
                        cmd.Parameters.AddWithValue("@Title", title);
                    }

                    if (description != null)
                    {
                        setParts.Add("description = @Description");
                        cmd.Parameters.AddWithValue("@Description", description);
                    }

                    if (category != null)
                    {
                        setParts.Add("category = @Category");
                        cmd.Parameters.AddWithValue("@Category", category);
                    }

                    if (value.HasValue)
                    {
                        setParts.Add("value = @Value");
                        cmd.Parameters.AddWithValue("@Value", value.Value);
                    }

                    if (date.HasValue)
                    {
                        setParts.Add("date = @Date");
                        cmd.Parameters.AddWithValue("@Date", date.Value);
                    }

                    if (setParts.Count == 0)
                    {
                        throw new ArgumentException("Nenhum campo para atualizar foi fornecido.");
                    }

                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.CommandText = $@"UPDATE incomes SET {string.Join(", ", setParts)} WHERE id = @Id";

                    int linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                    {
                        throw new Exception("Income não encontrado");
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao atualizar o income: {ex.Message} ", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao atualizar o income: {ex.Message} ", ex);

            }


        }

        public void DeleteIncome(int id)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    string sql = "DELETE FROM incomes WHERE id = @Id";
                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        var linhas = cmd.ExecuteNonQuery();

                        if (linhas == 0)
                        {
                            throw new Exception("Income não encontrado");
                        }
                    }
                }
            }
            catch (MySqlException ex) 
            {
                throw new Exception($"Erro ao deletar o income: {ex.Message} ", ex);
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro inesperado ao deletar o income: {ex.Message}", ex);
            }

        }
    }
}




