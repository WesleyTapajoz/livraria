using AutoMapper;
using Livraria.Domain;
using Livraria.Domain.Entity;
using Livraria.WebAPI.Dtos;

namespace Livraria.WebAPI.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>()
                 .ForMember(dest => dest.Id, opt => {
                     opt.MapFrom(src => src.Id);
                 })
                .ReverseMap();

            CreateMap<User, UserDto>()
               .ReverseMap();


            CreateMap<Reserva, ReservaDto>()
                .ReverseMap();

            CreateMap<Emprestimo, EmprestimoDto>()
                .ReverseMap();

            CreateMap<Livro, LivroDto>()
                .ReverseMap();

            CreateMap<User, UserLoginDto>()
                .ReverseMap();

            CreateMap<InstituicaoEnsino, InstituicaoEnsinoDto>()
             .ReverseMap();
        }
    }
}
