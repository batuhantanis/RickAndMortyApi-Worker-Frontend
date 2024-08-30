using EgeBilgi_Application.Response;
using EgeBilgi_Domain.Entitities;

namespace EgeBilgi_API.MediatR.Queries.Response.Character;

public class GetCharactersQueryResponse
{
    public ServiceResponse<List<GetCharacterResponse>> data { get; set; }
}