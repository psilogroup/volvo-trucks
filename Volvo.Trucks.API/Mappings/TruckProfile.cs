using AutoMapper;
using Volvo.Trucks.API.DTO;
using Volvo.Trucks.Domain.Enums;
using Volvo.Trucks.Domain.Model;

namespace Volvo.Trucks.API.Mappings
{
    public class TruckProfile : Profile
    {
        public class StringToModelTypeConverter : IValueConverter<string, ModelType>
        {
            public Domain.Enums.ModelType Convert(string source, ResolutionContext context)
                => source switch
                {
                    "FM" => ModelType.FM,
                    "FH" => ModelType.FH,
                    _ => throw new ArgumentException("Model only accepts FM out FH")
                };
        }

        public class ModelTypeToStringConverter : IValueConverter<ModelType,string>
        {
            public string Convert(ModelType source, ResolutionContext context)
                => source switch
                {
                    ModelType.FM => "FM",
                    ModelType.FH => "FH",
                    _ => throw new ArgumentException(" Unknow model")
                };
        }

        public TruckProfile()
        {
            CreateMap<TruckDTO, Truck>()
             .ForMember(
                 dest => dest.Id,
                 opt => opt.MapFrom(src => src.Id))
             .ForMember(
                 dest => dest.Model,
                 opt => opt.ConvertUsing(new StringToModelTypeConverter()))
             .ForMember(
                 dest => dest.ModelYear,
                 opt => opt.MapFrom(src => src.ModelYear))
             .ForMember(
                 dest => dest.ManufactuirngYear,
                 opt => opt.MapFrom(src => src.ManufacturingYear));


            CreateMap<Truck, TruckDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.ModelYear,
                    opt => opt.MapFrom(src => src.ModelYear))
                .ForMember(
                    dest => dest.ManufacturingYear,
                    opt => opt.MapFrom(src => src.ManufactuirngYear));
        }


    }
}
