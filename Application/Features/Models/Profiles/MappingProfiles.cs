using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();
            CreateMap<Model, GetListModelListItemDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.FuelName, opt => opt.MapFrom(src => src.Fuel.Name))
                .ForMember(dest => dest.TransmissionName, opt => opt.MapFrom(src => src.Transmission.Name))
                .ReverseMap();

            CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();
            CreateMap<Model, GetListByDynamicModelListItemDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.FuelName, opt => opt.MapFrom(src => src.Fuel.Name))
                .ForMember(dest => dest.TransmissionName, opt => opt.MapFrom(src => src.Transmission.Name))
                .ReverseMap();
        }
    }
}
