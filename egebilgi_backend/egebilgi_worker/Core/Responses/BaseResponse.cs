namespace egebilgi_worker.Core.Responses;

public class BaseResponse<T> where T:class
{
    public List<T> results { get; set; }
    public Info info { get; set; }
}

public class Info
{
    public int count { get; set; }
    public int pages { get; set; }
    public string next { get; set; }
}