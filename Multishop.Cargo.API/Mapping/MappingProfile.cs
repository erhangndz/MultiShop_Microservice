using AutoMapper;
using Multishop.Cargo.DTO.CargoDetailDtos;
using Multishop.Cargo.DTO.CompanyDtos;
using Multishop.Cargo.DTO.CustomerDtos;
using Multishop.Cargo.Entity.Entities;

namespace Multishop.Cargo.API.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyDto, Company>().ReverseMap();
            CreateMap<UpdateCompanyDto, Company>().ReverseMap();

            CreateMap<CreateCustomerDto, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDto, Customer>().ReverseMap();

            CreateMap<CreateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<UpdateCargoDetailDto, CargoDetail>().ReverseMap();
        }
    }
}
