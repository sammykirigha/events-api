using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Models;
using LINQtoCSV;

namespace eventsApi.Dtos.eventsDto
{
    public class EventDtoCsv
    {
        [CsvColumn(Name = "Id", FieldIndex = 1)]
        public Guid Id { get; set; }

        [CsvColumn(Name = "EventName", FieldIndex = 2)]
        public string EventName { get; set; } = string.Empty;

        [CsvColumn(Name = "EventDate", FieldIndex = 3, OutputFormat = "dd-MM-yyyy HH:mm")]
        public DateTimeOffset EventDate { get; set; }

        [CsvColumn(Name = "Location", FieldIndex = 4)]
        public string Location { get; set; } = string.Empty;

        [CsvColumn(Name = "Description", FieldIndex = 5)]
        public string Description { get; set; } = string.Empty;

        [CsvColumn(Name = "Capacity", FieldIndex = 6)]
        public int Capacity { get; set; }

    }
}