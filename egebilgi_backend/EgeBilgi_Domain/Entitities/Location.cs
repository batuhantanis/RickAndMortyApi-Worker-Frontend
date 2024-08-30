namespace EgeBilgi_Domain.Entitities;

public class Location : BaseEntity
{
    public string name { get; set; }
    public string type { get; set; }
    public string dimension { get; set; }
    public string url { get; set; }
    public DateTime created { get; set; }
    
    public List<Character> Characters { get; set; }
}