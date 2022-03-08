using AutoMapper;
using PromoAPI.Model;
using PromoAPI.Model.DTO;

namespace PromoAPI.Mapper
{
    public class PromoParkMapper : Profile
    {
        public PromoParkMapper()
        {
            CreateMap<PromoParkDTO ,PromoParkModel>().ReverseMap();

        }
    }
}
