using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Models;

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
        }
    }
}
