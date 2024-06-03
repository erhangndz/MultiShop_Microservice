using AutoMapper;
using Multishop.Images.Dtos;
using Multishop.Images.Entities;

namespace Multishop.Images.Mapping
{
    public class ImageMapping: Profile
    {
        public ImageMapping()
        {
            CreateMap<CreateImageDto, ImageDrive>().ReverseMap();
            CreateMap<ResultImageDto, ImageDrive>().ReverseMap();
            CreateMap<UpdateImageDto, ImageDrive>().ReverseMap();
        }
    }
}
