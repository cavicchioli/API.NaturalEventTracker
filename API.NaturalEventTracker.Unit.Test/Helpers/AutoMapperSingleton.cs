using API.NaturalEventTracker.Application.AutoMapper;
using AutoMapper;

namespace API.NaturalEventTracker.Unit.Test.Helpers
{
    public class AutoMapperSingleton
    {
        private static IMapper _mapper;
        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    IMapper mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
                    _mapper = mapper;
                }
                return _mapper;
            }
        }
    }
}
