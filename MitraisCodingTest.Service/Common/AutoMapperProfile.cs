using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MitraisCodingTest.Repository;
using MitraisCodingTest.Service.Models;
namespace MitraisCodingTest.Service.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<tblT_Registrasi, RegistrationModel>();
            CreateMap<RegistrationModel, tblT_Registrasi>();
        }
    
    }
}
