public interface IUserService
{
    bool CreateUser(User user);
    IEnumerable<User> GetUsers();
    User? GetUser(int id);
    bool UpdateUser(User user);
    bool DeleteUser(int id);
}