﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications;
using Talabat.BLL.Specifications.Products;
using Talabat.DAL.Entities;

namespace Talbat.API.Controllers
{
    // p5.4.7 ...coming from Repository/GenericRepository.cs
    // to continue steps after 5.4.7 please go to ProjectStepsAndNotes/ProductController_Old.cs 

    public class ProductController : BaseController
    {

        private readonly IGenericRepository<Product> _productsRepo;
        public ProductController(IGenericRepository<Product> productsRepo)
        {
            _productsRepo = productsRepo;
        }


        // ... 5.4.23 coming from GenericRepository
        // 5.4.24 make class that represent the specifications of products
        // 5.4.24 make ProductWithTypeAndBrandSpecifaication.cs
        // 5.4.24 go to ProductWithTypeAndBrandSpecifaication.cs ...
        // - as any entity that have eager loading prop (like the product with the productBrand) we make for it class
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            // ... 5.4.26 come back from ProductWithTypeAndBrandSpecifaication
            var spec = new ProductWithTypeAndBrandSpecifaication();
            var products = await _productsRepo.GetAllWithSpecAsync(spec);
            return Ok(products);
        }




        // ... p6.1 coming from ProjectStepsAndNotes/textfile.cs
        // p6.2 create GetProduct(int id) which will get a specific product with id
        // - it will be the same fuction above but
        //   a. the request will be "GET" with id,
        //   b. use "GetByIdWithSpecAsync" instead of "GetAllWithSpecAsync" 
        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProduct(int id)
        {
            //p6.3 go to ProductWithTypeAndBrandSpecifaication.cs and create ctor that takes id ...
            var spec = new ProductWithTypeAndBrandSpecifaication(id);
            var product = await _productsRepo.GetByIdWithSpecAsync(spec);
            return Ok(product);
        }
    }
}
