namespace NGsystem.Dents.Application.Features.Usuario.auth;
public record LoginRequestDto(string Usuario,string Password);
public record LoginResponseDto(string Usuario,string Token);

