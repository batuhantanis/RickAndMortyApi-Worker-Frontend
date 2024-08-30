using EgeBilgi_Application.Request;
using EgeBilgi_Application.Response;
using EgeBilgi_Domain.Entitities;

namespace EgeBilgi_Application.Services;

public interface ICharacterService
{
    public Task<ServiceResponse<List<GetCharacterResponse>>> GetCharacters(GetCharacterRequest request);
}