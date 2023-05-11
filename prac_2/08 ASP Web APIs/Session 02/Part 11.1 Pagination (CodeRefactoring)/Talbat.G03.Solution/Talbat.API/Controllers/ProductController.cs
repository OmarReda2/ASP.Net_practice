﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications;
using Talabat.BLL.Specifications.Products;
using Talabat.DAL.Entities;
using Talbat.API.DTO;
using Talbat.API.Errors;

namespace Talbat.API.Controllers
{
    public class ProductController : BaseController
    {

        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _brandsRepo;
        private readonly IGenericRepository<ProductType> _typesRepo;
        private readonly IMapper _mapper;


        public ProductController(IGenericRepository<Product> productsRepo
            , IGenericRepository<ProductBrand> brandsRepo
            , IGenericRepository<ProductType> typesRepo
            , IMapper mapper)
        {
            _productsRepo = productsRepo;
            _brandsRepo = brandsRepo;
            _typesRepo = typesRepo;
            _mapper = mapper;
        }



        
        [HttpGet]
        // ... p11.1  coming from TextFile.cs
        // p11.2 we will add pageSize and PageNumber as a Param
        // - if there are more than 3 param in function
        //   we shoulld but all param in class make obj of it and passes it in the function
        // p11.3 create TRalabat.API/Specifications/Product/ProductSpecParam.cs

        //... 11.4 coming from TRalabat.API/Specifications/Product/ProductSpecParam.cs
        // 11.5 add the ProductSpecParam obj instead of old Params
        // - when putting an obj as param we should put before it [FromQuery]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts([FromQuery]ProductSpecParam productsParam)

        {
            // 11.6 adjust all old param to its prop in obj
            var spec = new ProductWithTypeAndBrandSpecifaication(productsParam);
            var products = await _productsRepo.GetAllWithSpecAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products));

        }





        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            /*
            var spec = new ProductWithTypeAndBrandSpecifaication(id);
            var product = await _productsRepo.GetByIdWithSpecAsync(spec);

            if (product == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Product, ProductToReturnDTO>(product));
            */

            // p8.4 editing code
            var spec = new ProductWithTypeAndBrandSpecifaication(id);
            var product = await _productsRepo.GetByIdWithSpecAsync(spec);

            var productDto = _mapper.Map<Product, ProductToReturnDTO>(product);
            if(productDto == null) return NotFound(new ApiResponse(404));
            
            return Ok(productDto);
        }



        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBarnds()
        {
            var brands = await _brandsRepo.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            var types = await _typesRepo.GetAllAsync();
            return Ok(types);
        }
    }
}