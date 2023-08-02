namespace WebApplication1.Business.Interfaces
{
    public interface IUrlBusiness
    {
        string GetShortUrl(string url);
        string GetLongUrl(string url);
    }
}
