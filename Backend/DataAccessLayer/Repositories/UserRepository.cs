using Medfar.Interview.Types;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Data.SqlClient;

namespace Medfar.Interview.DAL.Repositories
{
    public class UserRepository
    {
        private static string _connectionString = @"Data Source=DESKTOP-JL3C9CP\SQLEXPRESS;Initial Catalog=MEDFAR_DEV_INTERVIEW;Integrated Security=True";
        private static SqlConnection _dbConnection;

        private readonly ILogger<UserRepository> _logger;




        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }

        public List<User> GetAll()
        {
            //_logger.LogInformation("Fetching all users.");
            //_dbConnection = new SqlConnection(_connectionString);


            //SqlCommand command = new("SELECT * FROM Users", _dbConnection);

            //_dbConnection.Open();

            //SqlDataReader reader = command.ExecuteReader();

            //List<User> messages = new List<User>();
            ////User obj = default(User);
            //while (reader.Read())
            //{
            //    User message = new();

            //    message.id = (Guid)reader["id"];
            //    message.last_name = (string)reader["last_name"];
            //    message.first_name = (string)reader["first_name"];
            //    message.email = (string)reader["email"];
            //    message.date_created = (DateTime)reader["date_created"];

            //    messages.Add(message);
            //}
            //_dbConnection.Close();
            //return messages;

            _logger.LogInformation("Fetching all users.");

            using (var _dbConnection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Users", _dbConnection);

                try
                {
                    _dbConnection.Open();
                    var reader = command.ExecuteReader();

                    var users = new List<User>();
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            id = (Guid)reader["id"],
                            last_name = (string)reader["last_name"],
                            first_name = (string)reader["first_name"],
                            email = (string)reader["email"],
                            date_created = (DateTime)reader["date_created"]
                        };
                        users.Add(user);
                    }

                    _logger.LogInformation("Successfully fetched {Count} users.", users.Count);
                    return users;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching users.");
                    throw; // Re-throw the exception to be handled by the caller
                }
            }
        }

        public List<User> GetById(Guid id)
        {
            //_logger.LogInformation("Fetching user with ID: {Id}", id);
            //_dbConnection = new SqlConnection(_connectionString);

            //string sqlQuery = @"SELECT * FROM" +
            //                  " Users " +
            //                  "WHERE id = '" + id +"'";
            //SqlCommand command = new SqlCommand(sqlQuery, _dbConnection);

            //_dbConnection.Open();
            //SqlDataReader reader = command.ExecuteReader();

            //List<User> messages = new List<User>();
            ////User obj = default(User);
            //while (reader.Read())
            //{
            //    User message = new User();

            //    message.id = (Guid)reader["id"];
            //    message.last_name = (string)reader["last_name"];
            //    message.first_name = (string)reader["first_name"];
            //    message.email = (string)reader["email"];
            //    message.date_created = (DateTime)reader["date_created"];

            //    messages.Add(message);
            //}
            //return messages;
            _logger.LogInformation("Fetching user with ID: {Id}", id);

            using (var _dbConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = @"SELECT * FROM Users WHERE id = @Id";
                var command = new SqlCommand(sqlQuery, _dbConnection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    _dbConnection.Open();
                    var reader = command.ExecuteReader();

                    var users = new List<User>();
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            id = (Guid)reader["id"],
                            last_name = (string)reader["last_name"],
                            first_name = (string)reader["first_name"],
                            email = (string)reader["email"],
                            date_created = (DateTime)reader["date_created"]
                        };
                        users.Add(user);
                    }

                    _logger.LogInformation("Successfully fetched {Count} users with ID: {Id}", users.Count, id);
                    return users;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching user with ID: {Id}", id);
                    throw; // Re-throw the exception to be handled by the caller
                }
            }
        }

        public List<User> GetByEmail(string email)
        {
            //_dbConnection = new SqlConnection(_connectionString);

            //string sqlQuery = @"SELECT * FROM" +
            //                  " Users " +
            //                  "WHERE email  = '" + _email + "'";
            //SqlCommand command = new SqlCommand(sqlQuery, _dbConnection);

            //_dbConnection.Open();
            //SqlDataReader reader = command.ExecuteReader();

            //List<User> users = new List<User>();
            ////User obj = default(User);
            //while (reader.Read())
            //{
            //    User user = new User();

            //    user.id = (Guid)reader["id"];
            //    user.last_name = (string)reader["last_name"];
            //    user.first_name = (string)reader["first_name"];
            //    user.email = (string)reader["email"];
            //    user.date_created = (DateTime)reader["date_created"];

            //    users.Add(user);
            //}
            //_dbConnection.Close();
            //return users;

            _logger.LogInformation("Fetching user with email: {Email}", email);

            using (var _dbConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = @"SELECT * FROM Users WHERE email = @Email";
                var command = new SqlCommand(sqlQuery, _dbConnection);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    _dbConnection.Open();
                    var reader = command.ExecuteReader();

                    var users = new List<User>();
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            id = (Guid)reader["id"],
                            last_name = (string)reader["last_name"],
                            first_name = (string)reader["first_name"],
                            email = (string)reader["email"],
                            date_created = (DateTime)reader["date_created"]
                        };
                        users.Add(user);
                    }

                    _logger.LogInformation("Successfully fetched {Count} users with email: {Email}", users.Count, email);
                    return users;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching user with email: {Email}", email);
                    throw; // Re-throw the exception to be handled by the caller
                }
            }
        }

        public int Insert(UserDTO u)
        {
            //_dbConnection = new SqlConnection(_connectionString);   

            //string sqlQuery = @"INSERT INTO" +
            //                  " Users " +
            //                  "values ('" + u.id + "', '" + u.last_name + "', '" + u.first_name + "', '" + u.email + "', '" + u.date_created + "')";

            //SqlCommand command = new SqlCommand(sqlQuery, _dbConnection);

            //_dbConnection.Open();

            //int nbresult = command.ExecuteNonQuery();

            //return nbresult;
            _logger.LogInformation("Inserting user with email: {Email}", u.email);

            using (var _dbConnection = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"INSERT INTO Users (id, last_name, first_name, email, date_created) 
                            VALUES (@Id, @LastName, @FirstName, @Email, @DateCreated)";

                using (var command = new SqlCommand(sqlQuery, _dbConnection))
                {
                    // Using parameterized queries to prevent SQL injection
                    command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    command.Parameters.AddWithValue("@LastName", u.last_name);
                    command.Parameters.AddWithValue("@FirstName", u.first_name);
                    command.Parameters.AddWithValue("@Email", u.email);
                    command.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                    try
                    {
                        //not needed close when using statement
                        _dbConnection.Open();


                        // Execute the command and return the number of affected rows
                        return command.ExecuteNonQuery();
                        _logger.LogInformation("User with email: {Email} inserted successfully.", u.email);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error inserting user with email: {Email}", u.email);
                        throw; // Re-throw the exception to be handled by the caller
                    }
                }
            }

        }

        public int Update(User u)
        {
            _dbConnection = new SqlConnection(_connectionString);

            string sqlQuery = @"UPDATE   " +
                              " Users" +
                              " SET last_name='" + u.last_name + "', first_name='" + u.first_name + "', email='" + u.email + "', date_created='" + u.date_created + "' " +
                              "WHERE id= '" + u.id + "'";

            SqlCommand command = new SqlCommand(sqlQuery, _dbConnection);
            _dbConnection.Open();

            int nbresult = command.ExecuteNonQuery();

            return nbresult;
        }

        public int Delete(User u)
        {
            _dbConnection = new SqlConnection(_connectionString);

            string sqlQuery = @"DELETE FROM  " +
                                 " Users " +
                                 " WHERE id= '" + u.id + "'";

            SqlCommand command = new SqlCommand(sqlQuery, _dbConnection);

            _dbConnection.Open();

            int nbresult = command.ExecuteNonQuery();

            return nbresult;
        }

    }
}