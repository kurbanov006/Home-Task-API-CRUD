using Dapper;
using Npgsql;

public class UserService : IUserService
{
    public bool CreateUser(User user)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();

                return connection.Execute(SqlCommand.CreateUser, user) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public bool DeleteUser(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();

                return connection.Execute(SqlCommand.DeleteUser, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public User? GetUser(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<User>(SqlCommand.GetUser, new { Id = id });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public IEnumerable<User> GetUsers()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();

                return connection.Query<User>(SqlCommand.GetUsers);
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public bool UpdateUser(User user)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();

                return connection.Execute(SqlCommand.UpdateUser, user) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}



file class SqlCommand
{
    public const string ConnectionString = "Server=localhost; Port=5432; Database=users_db; User Id=postgres; Password=12345";

    public const string CreateUser = "insert into users(id, username, email, address) values(@id, @username, @email, @address)";
    public const string GetUsers = "select * from users";
    public const string GetUser = "select * from users where id = @id";
    public const string UpdateUser = "update users set username=@username, email=@email, address=@address where id = @id";
    public const string DeleteUser = "delete from users where id = @id";
}