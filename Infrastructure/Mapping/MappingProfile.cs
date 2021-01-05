using AutoMapper;

namespace WhatToBuy
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToBuyList, ListDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}