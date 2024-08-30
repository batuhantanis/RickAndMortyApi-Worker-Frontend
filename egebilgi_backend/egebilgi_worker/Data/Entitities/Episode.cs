namespace egebilgi_worker.Data.Entitities;

public class Episode : BaseEntity
{
    public string name { get; set; }
    public string air_date { get; set; }
    public string episode { get; set; }
    public string url { get; set; }
    public DateTime created { get; set; }
    
    public List<CharacterEpisode> CharacterEpisodes { get; set; }
}