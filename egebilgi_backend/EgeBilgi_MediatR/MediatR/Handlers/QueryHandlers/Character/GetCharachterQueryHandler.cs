
using EgeBilgi_API.MediatR.Queries.Request.Character;
using EgeBilgi_API.MediatR.Queries.Response.Character;
using EgeBilgi_Application.Request;
using EgeBilgi_Application.Services;
using MediatR;

namespace EgeBilgi_MediatR.MediatR.Handlers.QueryHandlers.Character;

public class GetCharachterQueryHandler : IRequestHandler<GetCharacterQueryRequest,GetCharactersQueryResponse>
{
    private readonly ICharacterService _characterService;
    

    public GetCharachterQueryHandler(ICharacterService characterService)
    {
        _characterService = characterService;
        
    }
    public async Task<GetCharactersQueryResponse> Handle(GetCharacterQueryRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = new GetCharacterRequest()
        {
            pageNumber = request.pageNumber,
            Take = request.Take
        };
        var result = await _characterService.GetCharacters(serviceRequest);

        var response = new GetCharactersQueryResponse()
        {
            data = result
        };

        return response;

    }
}