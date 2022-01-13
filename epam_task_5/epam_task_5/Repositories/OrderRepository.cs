using epam_task_5.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess.Repositories
{
    /// <summary>
    /// class for accessing the order table
    /// </summary>
    public class OrderRepository
    {
        private readonly string connectionString;

        public OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Create new element in order table
        /// </summary>
        /// <param name="item">new element</param>
        /// <returns>id of new element</returns>
        public int Create(Order item)
        {
           // IdBook, IdClient, OrderDate, Returned, Condition
            string sqlExpression = $"INSERT INTO [Order] (IdBook, IdClient, OrderDate, ReturnCondition)" +
                " VALUES (@idBook, @idClient, @orderDate, @returnCondition); SELECT SCOPE_IDENTITY()";

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
                            new SqlParameter("@returnCondition", item.ReturnCondition),

                        });

                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// method to delete element
        /// </summary>
        /// <param name="id">id of need element</param>
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
        /// <summary>
        /// method to get all element from order table
        /// </summary>
        /// <returns>List of all element from table</returns>
        public IEnumerable<Order> GetAll()
        {
            string sqlExpression = "SELECT Id, IdBook, IdClient, OrderDate, ReturnCondition FROM [Order]";
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
                                ReturnCondition = (Enums.ConditionEnum)int.Parse(reader["ReturnCondition"].ToString()),
                            });
                        }
                    }
                }
            }

            return client;
        }

        /// <summary>
        /// Method to get need element
        /// </summary>
        /// <param name="id">id need element</param>
        /// <returns>need element</returns>
        public Order GetById(int id)
        {
            string sqlExpression = "SELECT Id, IdBook, IdClient, OrderDate, ReturnCondition FROM [Order]" +
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
                            ReturnCondition = (Enums.ConditionEnum)int.Parse(reader["ReturnCondition"].ToString()),
                        } : null;
                    }
                }
            }
        }
        /// <summary>
        /// Method to update element
        /// </summary>
        /// <param name="item">new element</param>
        public void Update(Order item)
        {
            //IdBook, IdClient, OrderDate, Returned, Condition
            string sqlExpression = "UPDATE [Order] SET IdBook=@idBook, IdClient=@idClient, OrderDate=@orderDate, ReturnCondition=@returnCondition " +
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
                            new SqlParameter("@condition", item.ReturnCondition),
                        });

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
