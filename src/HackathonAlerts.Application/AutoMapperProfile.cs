using AutoMapper;
using HackathonAlerts.Domain.Dto;
using HackathonAlerts.Domain.Models;

namespace HackathonAlerts.Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Alert, AlertDto>();
    }
}