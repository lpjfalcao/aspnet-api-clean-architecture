﻿using AutoMapper;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Reflection;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enum;
using TaskManager.Infra.Data.DataTransferObjects;

namespace TaskManager.Application.MappingProfiles
{
    public class TarefaMappingProfile : Profile
    {
        public TarefaMappingProfile()
        {
            CreateMap<Tarefa, TarefaDto>()
                .ForMember(x => x.Status, opt => opt.MapFrom(x => GetDescriptionFromStatusValue<TarefaStatusEnum>(x.Status)))
                .ForMember(x => x.Prioridade, opt => opt.MapFrom(x => GetDescriptionFromStatusValue<PrioridadeTarefaEnum?>(x.Prioridade)));                             

            CreateMap<TarefaDto, Tarefa>()
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status));

            CreateMap<TarefaCreationDto, Tarefa>();

            CreateMap<Tarefa, TarefaUpdateDto>()
                .ReverseMap();
        }

        private string GetDescriptionFromStatusValue<T>(T status) 
        {
            FieldInfo field = status.GetType().GetField(status.ToString());
            DescriptionAttribute attribute =
                (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute != null ? attribute.Description : status.ToString();
        }
    }
}
