

using eventsApi.Dtos.eventsDto;
using LINQtoCSV;

namespace eventsApi.Helpers
{
    public static class ReadCsvFile
    {
        public static IEnumerable<EventDtoCsv> ReadCsvFromFile() {
          var csvFileDescription = new CsvFileDescription
          {
            FirstLineHasColumnNames = true,
            IgnoreUnknownColumns = true,
            SeparatorChar = ',',
            UseFieldIndexForReadingData = false
          };

          var csvcontext = new CsvContext();

          var evnts = csvcontext.Read<EventDtoCsv>(@"D:\PROJECTS\WORK-PROJECTS\DOTNET\events\api\eventsApi\Helpers\EventsCsv.csv", csvFileDescription);   

          return evnts;
        }
    }
}