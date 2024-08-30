using EgeBilgi_API.MediatR.Queries.Request.Character;
using EgeBilgi_Application.Request;
using EgeBilgi_Application.Response;
using EgeBilgi_Application.Services;
using EgeBilgi_Domain.Entitities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EgeBilgi_API.Controllers;

public class DataController : BaseController
{
    private readonly IMediator _mediator;


    public DataController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("GetCharacters")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterResponse>>>> GetCharacters(GetCharacterQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return response.data;
    }
}