using AutoMapper;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Dtos.FeatureSliderDtos;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Dtos.ProductPhotoDtos;
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<ResultCategoryDto, Category>().ReverseMap();

            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<ResultProductDto, Product>().ReverseMap();

            CreateMap<CreateProductDetailDto, ProductDetail>().ReverseMap();
            CreateMap<UpdateProductDetailDto, ProductDetail>().ReverseMap();
            CreateMap<ResultProductDetailDto, ProductDetail>().ReverseMap();

            CreateMap<CreateProductPhotoDto, ProductPhoto>().ReverseMap();
            CreateMap<UpdateProductPhotoDto, ProductPhoto>().ReverseMap();
            CreateMap<ResultProductPhotoDto, ProductPhoto>().ReverseMap();


            CreateMap<CreateFeatureSliderDto,FeatureSlider>().ReverseMap();
            CreateMap<UpdateFeatureSliderDto,FeatureSlider>().ReverseMap();
            CreateMap<ResultFeatureSliderDto,FeatureSlider>().ReverseMap();
        }
    }
}
