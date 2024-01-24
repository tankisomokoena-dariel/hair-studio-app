using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public class GenericProfile<TEntity,TDto> : Profile
    {
        public GenericProfile()
        {
            CreateMap<TEntity,TDto>()
                .ReverseMap();
        } 
    }
}
