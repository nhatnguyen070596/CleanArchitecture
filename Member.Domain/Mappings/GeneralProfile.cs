using System;
using AutoMapper;
using Member.Domain.DTOs;
using Member.Domain.Entities;

namespace Member.Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}

