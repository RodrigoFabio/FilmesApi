using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile: Profile
{
    public CinemaProfile() 
    {
        CreateMap<CreateCinemaDto, Cinema>();
        //mapeia o tipo cinema para o tipo ReadCinemaDto, e onde temos Endereco, iremos mapear para ReadEnderecoDto
        //cinema vira ReadcinemaDto
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco));
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}
