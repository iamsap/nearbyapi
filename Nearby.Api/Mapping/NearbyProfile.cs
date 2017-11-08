using System;
using AutoMapper;
using Nearby.Api.Data;
using Nearby.Api.Dtos;

namespace Nearby.Api.Mapping
{
    public class NearbyProfile : Profile
    {
        public NearbyProfile()
        {
            CreateMap<SubscribeRequestDto, Subscription>();
        }
    }
}
