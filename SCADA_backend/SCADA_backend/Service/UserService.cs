using SCADA_backend.DTO;
using SCADA_backend.Model;
using SCADA_backend.Repository;

namespace SCADA_backend.Service;

public class UserService
{
    public static void Login(LoginDTO login)
    {
        var user = UserRepository.GetByUsername(login.Username) ?? throw new ArgumentException("Username or password do not match!");
        if (user.Password != login.Password)
            throw new ArgumentException("Username or password do not match!");
        // UserRepository.Login(user);
    }
    
    public static void Register(LoginDTO userInfo)
    {
        if (UserRepository.GetByUsername(userInfo.Username) != null)
            throw new ArgumentException("Username already in use!");
        var user = new User(userInfo.Username, userInfo.Password);
        UserRepository.Save(user);
    }
}