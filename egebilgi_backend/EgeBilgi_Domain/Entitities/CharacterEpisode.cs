namespace EgeBilgi_Domain.Entitities;

public class CharacterEpisode : BaseEntity
{
    public int CharacterId { get; set; }
    public Character Character { get; set; }

    public int EpisodeId { get; set; }
    public Episode Episode { get; set; }
}