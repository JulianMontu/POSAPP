using AutoMapper;
using POS.Aplication.DTOS.Request;
using POS.Aplication.DTOS.Response;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases;
using POS.Utilities.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile() 
        {
            CreateMap<Category,CategoryResponseDTO>()
                .ForMember(x => x.StateCategory, x => x.MapFrom(y => y.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDTO>>()
                .ReverseMap();

            CreateMap<CategoryRequestDTO, Category>();

            CreateMap<Category, CategorySelectResponseDTO>()
                .ReverseMap();

        }
    }
}
