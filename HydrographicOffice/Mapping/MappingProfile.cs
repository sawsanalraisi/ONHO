using AutoMapper;
using Hydro.BAL.DTO;
using Hydro.DAL.Entities;
using HydrographicOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<NoticeToMariner, NoticeToMarinerDto>().ReverseMap();
            CreateMap<NoticeToMariner, NoticeToMVm>().ReverseMap();
            CreateMap<NavigationWarning, NavigationWarningDto>().ReverseMap();
            CreateMap<NavigationWarning, NavigationWVm>().ReverseMap();
            CreateMap<DifferentReport, DifferentReVm>().ReverseMap();
            CreateMap<DifferentReport, DifferentRepDto>().ReverseMap();
            CreateMap<NewFeature, NewFeatureVm>().ReverseMap();
            CreateMap<SpecialTask, SpecialTaskVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryVm>().ReverseMap();
            CreateMap<FileFormat, FileFormatDto>().ReverseMap();
            CreateMap<ServiceRequestType, ServiceVm>().ReverseMap();
            CreateMap<ServiceRequestType, ServiceRequestTypeDto>().ReverseMap();
            CreateMap<NewSurvey, NewSurveyVm>().ReverseMap();
            CreateMap<NewSurvey, NewSurveyDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterUserMVm>().ReverseMap();
            CreateMap<User, LoginRegisterVm>().ReverseMap();










        }
    }
}
