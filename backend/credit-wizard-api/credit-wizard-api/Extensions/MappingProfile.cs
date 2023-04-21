using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace credit_wizard_api.Extensions
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Creates a mapping profile for the automapper.
        /// When used it converts automatic the Source to the Destination
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Degree, DegreeDto>()
                .ForMember(dest => dest.DegreeModulDtos, act => act.MapFrom(src => src.DegreeModuls))
                .ReverseMap();

            CreateMap<DegreeModul, DegreeModulDto>()
                .ForMember(dest => dest.DegreeDto, act => act.MapFrom(src => src.Degree))
                .ForMember(dest => dest.ModulDto, act => act.MapFrom(src => src.Modul))
                .ReverseMap();
            
            CreateMap<Modul, ModulDto>()
                .ForMember(dest => dest.SemesterTimeSlotDtos, act => act.MapFrom(src => src.SemesterTimeSlot))
                .ForMember(dest => dest.DegreeModulDtos, act => act.MapFrom(src => src.DegreeModuls))
                .ReverseMap();

            CreateMap<SemesterTimeSlot, SemesterTimeSlotDto>().ReverseMap();

            CreateMap<Semester, SemesterDto>()
                .ForMember(dest => dest.SemesterPlannerDtos, act => act.MapFrom(src => src.SemesterPlanners))
                .ReverseMap();

            CreateMap<SemesterPlannerModul, SemesterPlannerModulDto>()
                .ForMember(dest => dest.SemesterPlannerDto, act => act.MapFrom(src => src.SemesterPlanner))
                .ForMember(dest => dest.ModulDto, act => act.MapFrom(src => src.Modul))
                .ReverseMap();

            CreateMap<SemesterPlanner, SemesterPlannerDto>()
                .ForMember(dest => dest.SemesterDto, act => act.MapFrom(src => src.Semester))
                .ForMember(dest => dest.SemesterPlannerModulDtos, act => act.MapFrom(src => src.SemesterPlannerModuls))
                .ForMember(dest => dest.SemesterTimeSlotDto, act => act.MapFrom(src => src.SemesterTimeSlot))
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.DegreeDto, act => act.MapFrom(src => src.Degree))
                .ForMember(dest => dest.SemesterPlannersDtos, act => act.MapFrom(src => src.SemesterPlanners));

        }
    }
}
