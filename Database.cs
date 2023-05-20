
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RatingSystem
{
    public class Database
    {
        private readonly string connectionString;

        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Tuple<bool, User> AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE login = @login AND Password = @password", connection);
                command.Parameters.AddWithValue("@login", username);
                command.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = Convert.ToString(reader.GetGuid(reader.GetOrdinal("UserId")));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        User user = new User(id, name);
                        Tuple<bool, User> tuple = Tuple.Create(true, user);

                        reader.Close();
                        return tuple;
                    }
                }
                reader.Close();
                return Tuple.Create(false, new User("", ""));
                
            }
        }

        public void RegisterUser(string username, string password)
        {
            // Создаем соединение с базой данных
            using (var connection = new SqlConnection(connectionString))
            {
                // Открываем соединение
                connection.Open();

                // Создаем команду для добавления нового пользователя
                using (var command = new SqlCommand("INSERT INTO Users (login, password) VALUES (@login, @password)", connection))
                {
                    // Добавляем параметры к команде
                    command.Parameters.AddWithValue("@login", username);
                    command.Parameters.AddWithValue("@password", password);

                    // Выполняем команду
                    command.ExecuteNonQuery();
                }
            }
        }

        
        public List<Employee> GetTopRatedEmployees(int count)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TOP (@Count) * FROM Employees ORDER BY averageRating DESC", connection);
                command.Parameters.AddWithValue("@Count", count);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string Id = Convert.ToString(reader.GetGuid(reader.GetOrdinal("employeeId")));
                    string Name = reader.GetString(reader.GetOrdinal("name"));
                    int Rating = reader.GetInt32(reader.GetOrdinal("averageRating"));
                    string PhotoPath = reader.GetString(reader.GetOrdinal("photoPath"));
                    Employee employee = new Employee(Id, Name, PhotoPath, Rating);
                    employees.Add(employee);
                }

                reader.Close();
            }

            return employees;
        }
        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Employees";
                var command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Id = Convert.ToString(reader.GetGuid(reader.GetOrdinal("employeeId")));
                    string Name = reader.GetString(reader.GetOrdinal("name"));
                    int Rating = reader.GetInt32(reader.GetOrdinal("averageRating"));
                    string PhotoPath = reader.GetString(reader.GetOrdinal("photoPath"));
                    Employee employee = new Employee(Id, Name, PhotoPath, Rating);
                    employees.Add(employee);
                }
                reader.Close();
            }
            return employees;
        }

        public void SaveComment(string userId, string employeeId, string text)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Comments(userId, employeeId, comment_text) VALUES(@userId, @employeeId, @text)", connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                command.Parameters.AddWithValue("@text", text);
                command.ExecuteNonQuery();

            }
        }

        public List<Tuple<string, string>> GetComments(string employeeId)
        {
            List<Tuple<string, string>> comments = new List<Tuple<string, string>>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT userId, comment_text FROM Comments WHERE employeeId = @employeeId ORDER BY createdAt ASC";

                connection.Open();
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string userId = Convert.ToString(reader.GetGuid(reader.GetOrdinal("userId")));
                    string text = reader.GetString(reader.GetOrdinal("comment_text"));
                    comments.Add(Tuple.Create(userId, text));
                }
                reader.Close();
            }
            return comments;
        }

        public string GetName(string userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT name FROM Users WHERE UserId = @userId";

                connection.Open();
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(reader.GetOrdinal("name"));
                    return name;
                }
                reader.Close();
            }
            return "";
        }

        public void SaveRating(string userId, string employeeId, int rating)
        {
            string query = "SELECT COUNT(*) FROM Rating WHERE userId = @userId AND employeeId = @employeeId";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@employeeId", employeeId);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Если запись существует, обновляем ее значение
                        query = "UPDATE Rating SET rating = @rating WHERE userId = @userId AND employeeId = @employeeId";
                        using (var updateCommand = new SqlCommand(query, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@userId", userId);
                            updateCommand.Parameters.AddWithValue("@employeeId", employeeId);
                            updateCommand.Parameters.AddWithValue("@rating", rating);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Если запись не существует, создаем новую
                        query = "INSERT INTO Rating (userId, employeeId, rating) VALUES (@userId, @employeeId, @rating)";
                        using (var insertCommand = new SqlCommand(query, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@userId", userId);
                            insertCommand.Parameters.AddWithValue("@employeeId", employeeId);
                            insertCommand.Parameters.AddWithValue("@rating", rating);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public int GetRating(string userId, string employeeId)
        {
            int rating = 0;
            string query = "SELECT rating FROM Rating WHERE userId = @userId AND employeeId = @employeeId";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@employeeId", employeeId);
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        rating = Convert.ToInt32(result);
                    }
                }
            }
            return rating;
        }
        public void SetAverageRating(string employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT rating FROM Rating WHERE employeeId = @employeeId";

                int averageRating = 0;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    SqlDataReader reader = command.ExecuteReader();

                    // Вычисляем среднюю оценку
                    int sum = 0;
                    int count = 0;
                    while (reader.Read())
                    {
                        sum += reader.GetInt32(0);
                        count++;
                    }
                    averageRating = (int)Math.Round((double)sum / count, MidpointRounding.AwayFromZero);

                    // Закрываем ридер и подключение
                    reader.Close();
                }
                query = "UPDATE Employees SET averageRating = @rating WHERE employeeId = @employeeId;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Устанавливаем параметры запроса
                    command.Parameters.AddWithValue("@rating", averageRating);
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    command.ExecuteNonQuery();

                }
            }
                
        }

        public bool Register(string login, string name, string password)
        {
            string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE login=@login";

            // запрос на добавление нового пользователя
            string insertUserQuery = "INSERT INTO Users (login, password, name) VALUES (@login, @password, @name)";

            // создание подключения к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // открытие подключения
                connection.Open();

                // создание команды для проверки существования пользователя
                SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection);

                // создание параметра для логина
                checkUserCommand.Parameters.AddWithValue("@login", login);

                // выполнение запроса на проверку существования пользователя
                int count = (int)checkUserCommand.ExecuteScalar();

                // если пользователь не существует, добавляем его в базу данных
                if (count == 0)
                {
                    // создание команды для добавления нового пользователя
                    SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, connection);

                    // создание параметров для логина, пароля и имени
                    insertUserCommand.Parameters.AddWithValue("@login", login);
                    insertUserCommand.Parameters.AddWithValue("@password", password);
                    insertUserCommand.Parameters.AddWithValue("@name", name);

                    // выполнение запроса на добавление нового пользователя
                    insertUserCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
