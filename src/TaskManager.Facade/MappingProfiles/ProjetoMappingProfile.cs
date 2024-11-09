using AutoMapper;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.DataTransferObjects;

namespace TaskManager.Application.MappingProfiles
{
    public class ProjetoMappingProfile : Profile
    {
        public ProjetoMappingProfile()
        {
            CreateMap<Projeto, ProjetoDto>();
            CreateMap<ProjetoCreationDto, Projeto>();
        }
    }
}
