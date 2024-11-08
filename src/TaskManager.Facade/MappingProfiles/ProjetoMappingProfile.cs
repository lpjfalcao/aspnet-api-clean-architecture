using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.DataTransferObjects;

namespace TaskManager.Application.MappingProfiles
{
    public class ProjetoMappingProfile : Profile
    {
        public ProjetoMappingProfile()
        {
            CreateMap<Projeto, ProjetoDto>();
        }
    }
}
