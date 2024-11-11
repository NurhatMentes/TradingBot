using Application.Features.Auth.DTOs;
using AutoMapper;
using Core.Entities.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserProfileDto>()
                .ForMember(dest => dest.Portfolios, opt => opt.MapFrom(src => src.PortfolioIds)).ReverseMap();

            CreateMap<Portfolio, PortfolioDto>()
                .ForMember(dest => dest.TotalValue, opt =>
                    opt.MapFrom(src => src.Balance + src.HoldingItems.Sum(h => h.Quantity))).ReverseMap();

            CreateMap<Trade, TradeDto>()
                .ForMember(dest => dest.Duration, opt =>
                    opt.MapFrom(src => src.ExitTime.HasValue
                        ? (src.ExitTime.Value - src.EntryTime).TotalHours
                        : (DateTime.UtcNow - src.EntryTime).TotalHours)).ReverseMap();

            CreateMap<TradingStrategy, TradingStrategyDto>().ReverseMap();

            CreateMap<HoldingItem, HoldingItemDto>().ReverseMap();
        }
    }
}

