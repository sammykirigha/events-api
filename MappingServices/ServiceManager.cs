using eventsApi.MappingServices;

namespace eventsApi.MappingServices;

public class ServiceManager : IServiceManager
{
    public void GenerateMerchandise()
    {
        Console.WriteLine($"Generate Merchandise: Long running task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void SendMail()
    {
        Console.WriteLine($"Sending Email: Long running task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void SyncData()
    {
        Console.WriteLine($"Syncing Data: Long running task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void UpdateDatabase()
    {
        Console.WriteLine($"Updating Databases: Long running task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }
}