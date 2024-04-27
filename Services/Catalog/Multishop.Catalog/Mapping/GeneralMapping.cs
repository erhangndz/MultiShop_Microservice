using AutoMapper;
using Multishop.Catalog.Dtos.AboutDtos;
using Multishop.Catalog.Dtos.BrandDtos;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Dtos.FeatureServiceDtos;
using Multishop.Catalog.Dtos.FeatureSliderDtos;
using Multishop.Catalog.Dtos.OfferDiscountDtos;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Dtos.ProductPhotoDtos;
using Multishop.Catalog.Dtos.SpecialOfferDtos;
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


            CreateMap<ResultSpecialOfferDto,SpecialOffer>().ReverseMap();
            CreateMap<CreateSpecialOfferDto,SpecialOffer>().ReverseMap();
            CreateMap<UpdateSpecialOfferDto,SpecialOffer>().ReverseMap();


            CreateMap<ResultFeatureServiceDto,FeatureService>().ReverseMap();
            CreateMap<CreateFeatureServiceDto,FeatureService>().ReverseMap();
            CreateMap<UpdateFeatureServiceDto,FeatureService>().ReverseMap();


            CreateMap<CreateOfferDiscountDto,OfferDiscount>().ReverseMap();
            CreateMap<UpdateOfferDiscountDto,OfferDiscount>().ReverseMap();
            CreateMap<ResultOfferDiscountDto,OfferDiscount>().ReverseMap();


            CreateMap<ResultBrandDto,Brand>().ReverseMap();
            CreateMap<CreateBrandDto,Brand>().ReverseMap();
            CreateMap<UpdateBrandDto,Brand>().ReverseMap();


            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<CreateAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();


        }
    }
}
