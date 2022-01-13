using epam_task_5.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess.Repositories
{
    public class BookRepository
    {
        private readonly string connectionString;

        public BookRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Create(Book item)
        {
            //Returned, Condition
            string sqlExpression = $"INSERT INTO [Book] (Name, Author, Genre, Returned, Condition)" +
                " VALUES (@name, @author, @genre, @returned, @condition); SELECT SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@name", item.Name),
                            new SqlParameter("@author", item.Author),
                            new SqlParameter("@genre", item.Genre),
                            new SqlParameter("@returned", item.Returned),
                            new SqlParameter("@condition", item.Condition),
               
                        });

                    return command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            string sqlExpression = "DELETE FROM [Book] WHERE Id=@id";

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

        public IEnumerable<Book> GetAll()
        {
            string sqlExpression = "SELECT Id, Name, Author, Genre, Returned, Condition FROM [Book]";
            List<Book> book = new List<Book>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book.Add(new Book()
                            {
                                Id = Convert.ToInt32(reader["Id"], null),
                                Name = (string)reader["Name"],
                                Author = (string)(reader["Author"]),
                                Genre = (string)(reader["Genre"]),
                                Returned = (Enums.StatusEnum)int.Parse(reader["Returned"].ToString()),
                                Condition = (Enums.ConditionEnum)int.Parse(reader["Condition"].ToString()),
                            });
                        }
                    }
                }
            }

            return book;
        }

        public Book GetById(int id)
        {
            string sqlExpression = "SELECT Id, Name, Author, Genre, Returned, Condition FROM [Book]" +
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
                        return reader.Read() ? new Book()
                        {
                            Id = Convert.ToInt32(reader["Id"], null),
                            Name = (string)reader["Name"],
                            Genre = (string)reader["Genre"],
                            Author = (string)reader["Genre"],
                            Returned = (Enums.StatusEnum)int.Parse(reader["Returned"].ToString()),
                            Condition = (Enums.ConditionEnum)int.Parse(reader["Condition"].ToString()),

                        } : null;
                    }
                }
            }
        }

        public void Update(Book item)
        {

            string sqlExpression = "UPDATE [Book] SET Name=@name, Author=@author, Genre=@genre, Returned=@returned, Condition=@condition " +
                " FROM [Book]" +
                " WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@id", item.Id),
                            new SqlParameter("@name", item.Name),
                            new SqlParameter("@author", item.Author),
                            new SqlParameter("@genre", item.Genre),
                            new SqlParameter("@returned", item.Returned),
                            new SqlParameter("@condition", item.Condition),

                        });

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
