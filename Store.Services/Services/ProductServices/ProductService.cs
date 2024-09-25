﻿using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Services.ProductServices;
using Store.Services.Services.ProductServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntity = Store.Data.Entities.Product;

namespace Store.Services.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitWork unitWork , IMapper mapper )
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitWork.Repository<ProductBrand, int>().GetAllAsNoTrackingAsync();
            var mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);
         
            return mappedBrands;
        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync()
        {
            var products = await _unitWork.Repository<ProductEntity, int>().GetAllAsNoTrackingAsync();
            var mappedProducts =  _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);
           
            return mappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitWork.Repository<ProductType, int>().GetAllAsNoTrackingAsync();
            var mappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);
          
            return mappedTypes;
        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? productId)
        {
            if(productId is null )
                throw new Exception("Id is Null");

            var product = await _unitWork.Repository<ProductEntity, int>().GetByIdAsync(productId.Value);


            if (product is null)
                throw new Exception("Product Not Found");

            var mappedProducts = _mapper.Map<ProductDetailsDto>(product);

          
            return mappedProducts;

        }
    }
}
