using epam_task_5.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess.Repositories
{
    public class ClientRepository
    {
        private readonly string connectionString;

        public ClientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Create(Client item)
        {

            string sqlExpression = $"INSERT INTO [Client] (FIO, DateOfBirth, Sex)" +
                " VALUES (@fIO, @dateOfBirth, @sex); SELECT SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@fIO", item.FIO),
                            new SqlParameter("@dateOfBirth", item.DateOfBirth),
                            new SqlParameter("@sex", item.Sex),

                        });

                    return command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            string sqlExpression = "DELETE FROM [Client] WHERE Id=@id";

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

        public IEnumerable<Client> GetAll()
        {
            string sqlExpression = "SELECT Id, FIO, DateOfBirth, Sex FROM [Client]";
            List<Client> client = new List<Client>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            client.Add(new Client()
                            {
                                Id = Convert.ToInt32(reader["Id"], null),
                                FIO = (string)reader["FIO"],
                                DateOfBirth = DateTimeOffset.Parse(reader["DateOfBirth"].ToString()),
                                Sex = (string)(reader["Sex"]),

                            });
                        }
                    }
                }
            }

            return client;
        }

        public Client GetById(int id)
        {
            string sqlExpression = "SELECT Id, FIO, DateOfBirth, Sex FROM [Client]" +
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
                        return reader.Read() ? new Client()
                        {
                            Id = Convert.ToInt32(reader["Id"], null),
                            FIO = (string)reader["FIO"],
                            DateOfBirth = DateTimeOffset.Parse(reader["DateOfBirth"].ToString()),
                            Sex = (string)(reader["Sex"]),
                        } : null;
                    }
                }
            }
        }

        public void Update(Client item)
        {
            // FIO, DateOfBirth, Sex
            string sqlExpression = "UPDATE [Client] SET FIO=@fIO, DateOfBirth=@dateOfBirth, Sex=@sex " +
                " FROM [Client]" +
                " WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id", item.Id),
                            new SqlParameter("@fIO", item.FIO),
                            new SqlParameter("@dateOfBirth", item.DateOfBirth),
                            new SqlParameter("@sex", item.Sex),
                        });

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
