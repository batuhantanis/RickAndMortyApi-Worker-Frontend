using EgeBilgi_API.MediatR.Queries.Response.Character;
using MediatR;

namespace EgeBilgi_API.MediatR.Queries.Request.Character;

public class GetCharacterQueryRequest : IRequest<GetCharactersQueryResponse>
{
    public int pageNumber { get; set; }
    public int Take { get; set; }
}