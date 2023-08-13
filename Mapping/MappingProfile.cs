using AutoMapper;
using MovieStore.Aplication.MovieOperation.Commands.CreateMovie;
using MovieStore.Aplication.MovieOperation.Commands.UpdateMovie;
using MovieStore.Aplication.MovieOperation.Queries.GetMovies;
using MovieStore.Entities;

namespace MovieStore.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie,CreateMovieCommandModel>().ReverseMap();
        CreateMap<Movie,UpdateMovieCommandModel>().ReverseMap();
        CreateMap<Movie,GetMoviesViewModel>().ReverseMap();


    }
    
}