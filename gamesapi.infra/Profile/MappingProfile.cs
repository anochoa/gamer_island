using AutoMapper;
using GamesApi.Infra.Modelo;
using GamesApi.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApi.Infra
{
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Amiibo, AmiiboDTO>()
              .ForMember(dto => dto.Character, amiibooo => amiibooo.MapFrom(m => m.Thecharacter))
              .ReverseMap();

            CreateMap<Amiibooo, AmiiboDTO>()
             .ForMember(dto => dto.Character, amiibooo => amiibooo.MapFrom(m => m.Thecharacter))
             .ReverseMap();

        }
    }

}
