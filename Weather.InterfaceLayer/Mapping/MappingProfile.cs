using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ec2.InterfaceLayer.DTO;

namespace Ec2.InterfaceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RunInstanceRequest, RunInstanceResponse>();
        }
    }
}
