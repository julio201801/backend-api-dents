using Microsoft.AspNetCore.Mvc;
using NGsystem.Dents.Application.Features.CreatePaciente;
using NGsystem.Dents.Application.Features.DeletePaciente;
using NGsystem.Dents.Application.Features.ListPacientes;
using NGsystem.Dents.Application.Features.UpdatePacientes;
using NGsystem.Dents.Domain.Common;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NGsystem.Dents.Api.Endpoints;

public static class PacienteEndpoint
{
    public static RouteGroupBuilder MapPacienteEndpoint(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/Paciente");
        api.MapGet("/ListaPaciente", ListPacienteEndpointAsync);
        api.MapGet("/ObtenerPaciente", GetPacienteEndpointAsync);
        api.MapPost("/GrabarPaciente", CreatePacienteEndpointAsync);
        api.MapPut("/UpdatePaciente", UpdatePacienteEndpointAsync);
        api.MapDelete("/DeletePaciente", DeletePacienteEndpointAsync);
        return api;
    }

    private static async Task<IResult> ListPacienteEndpointAsync([FromServices] ListPacienteHandler listPacienteHandler)
    {
        var result = await listPacienteHandler.Handle();
        return result.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<LisPacienteResponseDto>
            {
                Status = true,
                Lista = data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> GetPacienteEndpointAsync(GetPacienteHandler listPacienteHandler, [AsParameters] PacienteRequestDto request)
    {
        var result = await listPacienteHandler.Handle(request);
        return result.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<PacienteResponseDto>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> CreatePacienteEndpointAsync(CreatePacienteHandler createPacienteHandler, [FromBody] PacienteCreateRequestDto request)
    {
        var resultPaciente = await createPacienteHandler.Handle(request);
        return resultPaciente.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<PacienteCreateResponseDTO>
            {
                Status = true,
                registro =  data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> UpdatePacienteEndpointAsync(UpdatePacienteHandler updatePacienteHandler, [FromBody] PacienteUpdateRequestDto request)
    {
        var resultPaciente = await updatePacienteHandler.Handle(request);
        return resultPaciente.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<PacienteUpdateResponseDTO>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
    private static async Task<IResult> DeletePacienteEndpointAsync(DeletePacienteHandler deletePacienteHandler, [FromBody] PacienteDeleteRequestDto request)
    {
        var resultPaciente = await deletePacienteHandler.Handle(request);
        return resultPaciente.MatchApiException(
            onSuccess: (data) => TypedResults.Ok(new ResponseDto<PacienteDeleteResponseDTO>
            {
                Status = true,
                registro = data
            }),
            onFailure: (apiException) => throw apiException);
    }
}
