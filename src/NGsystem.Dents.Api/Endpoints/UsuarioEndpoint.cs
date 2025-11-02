using Microsoft.AspNetCore.Mvc;
using NGsystem.Dents.Application.Features.Pacientes.CreatePaciente;
using NGsystem.Dents.Application.Features.Usuario.auth;
using NGsystem.Dents.Application.Features.Usuario.CreateUsuario;
using NGsystem.Dents.Domain.Common;

namespace NGsystem.Dents.Api.Endpoints;

public static class UsuarioEndpoint
{
    public static RouteGroupBuilder MapUsuarioEndpoint(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/Usuario");
        api.MapPost("/GrabarPaciente", CreateUsuarioEndpointAsync);
        api.MapPost("/Authentication", GetLoginEndpointAsync);
        return api;
    }
    private static async Task<IResult> CreateUsuarioEndpointAsync(CreateUsuarioHandler createUsuarioHandler, [FromBody] UsuarioRequestDto request)
    {
        var resultPaciente = await createUsuarioHandler.Handle(request);
        return resultPaciente.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<UsuarioResponseDto>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> GetLoginEndpointAsync(LoginHandler loginHandler, [FromBody] LoginRequestDto request)
    {
        var resultLogin = await loginHandler.Handle(request);
        return resultLogin.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<LoginResponseDto>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
}
