﻿using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;

namespace BookOfHabitsMicroservice.Application.Services.Mapping
{
    public class HabitMapping : Profile 
    {
        public HabitMapping()
        {
            CreateMap<Habit, HabitModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));

            CreateMap<Repetition, RepetitionModel>();
            CreateMap<Delay, DelayModel>();
            CreateMap<TimeResetInterval, TimeResetIntervalModel>();       
        }
    }
}