using Microsoft.Extensions.Caching.Memory;

public class MyService
{
    private readonly IMemoryCache _cache;

    public MyService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void MyMethod()
    {
        string cacheKey = "myData";
        if (!_cache.TryGetValue(cacheKey, out string myData))
        {
            
            myData = GetDataFromDb();

            
            _cache.Set(cacheKey, myData, TimeSpan.FromMinutes(30));
        }

       
    }

    private string? GetDataFromDb()
    {
        throw new NotImplementedException();
    }
}