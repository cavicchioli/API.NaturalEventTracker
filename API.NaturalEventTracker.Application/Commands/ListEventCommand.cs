using API.NaturalEventTracker.Application.Commands.ValueObjects;
using API.NaturalEventTracker.Application.Responses;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.NaturalEventTracker.Application.Commands
{
    public class ListEventCommand : IRequest<IEnumerable<EventResponse>>
    {
        public int? Limit { get; set; }
        public int? Days { get; set; }

        [EnumDataType(typeof(EventStatus))]
        [JsonConverter(typeof(StringEnumConverter))]
        public string Status { get; set; }
        public string StartingDate { get; set; }
        public string EndingDate { get; set; }
        public string Category { get; set; }

        [EnumDataType(typeof(OrderTypes))]
        [JsonConverter(typeof(StringEnumConverter))]
        public string OrderBy { get; set; }
        [EnumDataType(typeof(OrderFields))]
        [JsonConverter(typeof(StringEnumConverter))]
        public string OrderField { get; set; }
    }
}
