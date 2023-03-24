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
            CreateMap<Degree, DegreeDto>().ReverseMap();
            CreateMap<Modul, ModulDto>().ReverseMap();
            CreateMap<Semester, SemesterDto>().ReverseMap();
            //CreateMap<SemesterPlannerModul, SemesterPlannerModulDto>()
            //    .ForMember(dest => dest.SemesterPlannerDto, act => act.MapFrom(src => src.SemesterPlanner))
            //    .ForMember(dest => dest.ModulDto, act => act.MapFrom(src => src.Modul))
            //    .ReverseMap();

            //CreateMap<SemesterPlanner, SemesterPlannerDto>()
            //    .ForMember(dest => dest.SemesterDto, act => act.MapFrom(src => src.Semester))
            //    .ForMember(dest => dest.SemesterPlannerModulDtos, act => act.MapFrom(src => src.SemesterPlannerModuls))
            //    .ReverseMap();

        }
    }
}
