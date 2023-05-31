namespace eventsApi.MappingServices;

public interface IServiceManager
{
     void SendMail();
     void SyncData();
     void GenerateMerchandise();
     void UpdateDatabase();
}