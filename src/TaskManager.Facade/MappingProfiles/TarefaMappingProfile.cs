using AutoMapper;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.DataTransferObjects;

namespace TaskManager.Application.MappingProfiles
{
    public class TarefaMappingProfile : Profile
    {
        public TarefaMappingProfile()
        {
            CreateMap<Tarefa, TarefaDto>();
            CreateMap<TarefaCreationDto, Tarefa>();
        }
    }
}
