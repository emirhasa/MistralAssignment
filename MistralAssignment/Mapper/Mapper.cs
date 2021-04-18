using AutoMapper;
using MistralAssignment.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Requests;

namespace MistralAssignment.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Show, ShowVM>();
            CreateMap<Actor, ActorVM>();
            CreateMap<ShowActor, ShowActorVM>();
            CreateMap<RatingInsertRequestVM, Rating>();
        }
    }
}
