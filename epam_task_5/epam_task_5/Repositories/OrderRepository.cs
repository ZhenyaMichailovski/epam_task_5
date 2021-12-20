using epam_task_5.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess.Repositories
{
    class OrderRepository
    {
        private readonly string connectionString;

        public OrderRepository()
        {
            this.connectionString = Connection.ConnectionString;
        }

        public int Create(Order item)
        {
           // IdBook, IdClient, OrderDate, Returned, Condition
            string sqlExpression = $"INSERT INTO [Order] (IdBook, IdClient, OrderDate, Returned, Condition)" +
                " VALUES (@idBook, @idClient, @orderDate, @returned, @condition); SELECT SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@idBook", item.IdBook),
                            new SqlParameter("@idClient", item.IdClient),
                            new SqlParameter("@orderDate", item.OrderDate),
                            new SqlParameter("@returned", item.Status),
                            new SqlParameter("@condition", item.Condition),

                        });

                    return command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            string sqlExpression = "DELETE FROM [Order] WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlParameter idParam = new SqlParameter("@id", id);
                    command.Parameters.Add(idParam);

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Order> GetAll()
        {
            string sqlExpression = "SELECT Id, IdBook, IdClient, OrderDate, Returned, Condition FROM [Order]";
            List<Order> client = new List<Order>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            client.Add(new Order()
                            {
                                Id = Convert.ToInt32(reader["Id"], null),
                                IdBook = (int)reader["IdBook"],
                                IdClient = (int)reader["IdClient"],
                                OrderDate = DateTimeOffset.Parse(reader["OrderDate"].ToString()),
                                Status = (Enums.StatusEnum)int.Parse(reader["Returned"].ToString()),
                                Condition = (Enums.ConditionEnum)int.Parse(reader["Condition"].ToString()),
                            });
                        }
                    }
                }
            }

            return client;
        }

        public Order GetById(int id)
        {
            string sqlExpression = "SELECT Id, IdBook, IdClient, OrderDate, Returned, Condition FROM [Order]" +
                " WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlParameter idParam = new SqlParameter(@"id", id);
                    command.Parameters.Add(idParam);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read() ? new Order()
                        {
                            Id = Convert.ToInt32(reader["Id"], null),
                            IdBook = (int)reader["IdBook"],
                            IdClient = (int)reader["IdClient"],
                            OrderDate = DateTimeOffset.Parse(reader["OrderDate"].ToString()),
                            Status = (Enums.StatusEnum)int.Parse(reader["Returned"].ToString()),
                            Condition = (Enums.ConditionEnum)int.Parse(reader["Condition"].ToString()),
                        } : null;
                    }
                }
            }
        }

        public void Update(Order item)
        {
            //IdBook, IdClient, OrderDate, Returned, Condition
            string sqlExpression = "UPDATE [Order] SET IdBook=@idBook, IdClient=@idClient, OrderDate=@orderDate, Returned=@returned, Condition=@condition " +
                " FROM [Order]" +
                " WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@idBook", item.IdBook),
                            new SqlParameter("@idClient", item.IdClient),
                            new SqlParameter("@orderDate", item.OrderDate),
                            new SqlParameter("@returned", item.Status),
                            new SqlParameter("@condition", item.Condition),
                        });

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
