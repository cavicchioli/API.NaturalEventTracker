using API.NaturalEventTracker.Application.Responses;
using API.NaturalEventTracker.Domain.Models;
using API.NaturalEventTracker.Domain.Models.ValueObjects;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.NaturalEventTracker.Application.AutoMapper
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Event, EventResponse>();

            CreateMap<Category, CategoryResponse>();

            CreateMap<Source, SourceResponse>();

            CreateMap<Geometry, GeometryResponse>()
                .ForMember(dest => dest.Coordinates, src => src.MapFrom(m => MapGeometry(m)));
        }

        private string MapGeometry(Geometry src)
        {
            if (Enum.IsDefined(typeof(GeometryType), src.Type))
            {
                if (src.Type.Equals(Enum.GetName(typeof(GeometryType), GeometryType.Point)))
                    return JsonConvert.SerializeObject(src.Coordinates, typeof(IEnumerable<Point>), null);

                if (src.Type.Equals(Enum.GetName(typeof(GeometryType), GeometryType.Polygon)))
                    return JsonConvert.SerializeObject(src.Coordinates, typeof(IEnumerable<Polygon>), null);
            }

            return default;
        }
    }
}
