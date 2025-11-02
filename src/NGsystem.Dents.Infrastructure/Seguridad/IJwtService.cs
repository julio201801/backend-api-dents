namespace NGsystem.Dents.Infrastructure.Seguridad;
public interface IJwtService
{
    string GenerateToken(string username, string role);
}


