namespace EgeBilgi_Application.Response;

public class ServiceResponse<T> where T:class
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool isSuccessfull { get; set; }
}