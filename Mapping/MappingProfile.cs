using AutoMapper;
using MovieStore.Aplication.ActorOperation.Commands.CreateActor;
using MovieStore.Aplication.ActorOperation.Commands.UpdateActor;
using MovieStore.Aplication.ActorOperation.Queries.GetActors;
using MovieStore.Aplication.CustomerOperation.Commands.CreateCustomer;
using MovieStore.Aplication.DirectorOperation.Commands.CreateDirector;
using MovieStore.Aplication.DirectorOperation.Commands.UpdateDirector;
using MovieStore.Aplication.DirectorOperation.Queries.GetDirectors;
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
        CreateMap<Customer,CreateCustomerCommandModel>().ReverseMap();
        CreateMap<Actor,CreateActorCommandModel>().ReverseMap();
        CreateMap<Actor,UpdateActorCommandModel>().ReverseMap();
        CreateMap<Actor,GetActorQueryViewModel>().ReverseMap();
        CreateMap<Director,CreateDirectorCommandModel>().ReverseMap();
        CreateMap<Director,UpdateDirectorCommandModel>().ReverseMap();
        CreateMap<Director,GetDirectorQueryViewModel>().ReverseMap();
        CreateMap<Director,GetDirectorQueryViewModel>().ReverseMap();


    }
    
}