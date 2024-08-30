using EgeBilgi_Domain.Entitities;

namespace EgeBilgi_Application.Response;

public class GetCharacterResponse
{
    public GetCharacterResponse()
    {
        Episodes = new List<Episode>();
    }
    public string name { get; set; }
    public string status { get; set; }
    public string species { get; set; }
    public string type { get; set; }
    public string gender { get; set; }
    public string image { get; set; }
    public string url { get; set; }

    public int OriginId { get; set; }
    public Origin origin { get; set; }

    public int LocationId { get; set; }
    public Location location { get; set; }
    
    public DateTime created { get; set; }

    public List<Episode> Episodes { get; set; }
}