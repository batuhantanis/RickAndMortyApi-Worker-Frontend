using EgeBilgi_Application.Request;
using EgeBilgi_Application.Response;
using EgeBilgi_Application.Services;
using EgeBilgi_Application.UnitOfWork;
using EgeBilgi_Domain.Entitities;

namespace EgeBilgi_Infrastructure.Services;

public class CharacterService : ICharacterService
{
    private readonly IUnitOfWork _unitOfWork;

    public CharacterService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ServiceResponse<List<GetCharacterResponse>>> GetCharacters(GetCharacterRequest request)
    {
        List<GetCharacterResponse> getCharacterResponses = new List<GetCharacterResponse>();
        if (request.Take > 0 && request.pageNumber < 83 && request.pageNumber >= 0)
        {
            var characters = await _unitOfWork.character.GetAll(take:request.Take,pageNumber:request.pageNumber,includes:new List<string>(){"location","origin"});
            if (characters.Count > 0)
            {
                

                foreach (var character in characters)
                {
                    var getAllCharacterEpisodes = await _unitOfWork.characterEpisode.GetAll(x => x.CharacterId == character.Id);

                    var episodeIds = getAllCharacterEpisodes.Select(x => x.EpisodeId).Distinct().ToList();
                    var getAllEpisodes = await _unitOfWork.episode.GetAll(x => episodeIds.Contains(x.Id));
                    GetCharacterResponse characterResponse = new GetCharacterResponse()
                    {
                        created = character.created,
                        gender = character.gender,
                        image = character.image,
                        location = character.location,
                        name = character.name,
                        origin = character.origin,
                        species = character.species,
                        status = character.status,
                        type = character.type,
                        url = character.url,
                        Episodes = getAllEpisodes.ToList(),
                        LocationId = character.LocationId,
                        OriginId = character.OriginId
                    };
                    getCharacterResponses.Add(characterResponse);
                }
                
                
                
                
                return new ServiceResponse<List<GetCharacterResponse>>()
                {
                    Data = getCharacterResponses,
                    isSuccessfull = true,
                    Message = "Success"
                };
                
            }
            else
            {
                return new ServiceResponse<List<GetCharacterResponse>>()
                {
                    Data = getCharacterResponses,
                    isSuccessfull = false,
                    Message = "Error"
                };
            }
            
        }
        else
        {
            return new ServiceResponse<List<GetCharacterResponse>>()
            {
                Data = getCharacterResponses,
                isSuccessfull = false,
                Message = "Error"
            };
        }
    }
}