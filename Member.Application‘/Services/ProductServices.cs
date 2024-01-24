using System;
using Member.Application_.Services.Interface;
using Member.Domain.DTOs;
using Member.Domain.Entities;

namespace Member.Application_.Services
{
    public class ProductServices : IProductServices
    {
        //Implement Bussiness Rule / USE CASES
        private readonly IProductRepository productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductResponse CreateProduct(CreateProductRequest request)
        {
            return this.productRepository.CreateProduct(request);
        }

        public void DeleteProductById(int productId)
        {
            this.productRepository.DeleteProductById(productId);
        }

        public ProductResponse GetProductById(int productId)
        {
            return this.productRepository.GetProductById(productId);
        }

        public List<ProductResponse> GetProducts()
        {
            return this.productRepository.GetProducts();
        }

        public ProductResponse UpdateProduct(int productId, UpdateProductRequest request)
        {
            return this.productRepository.UpdateProduct(productId, request);
        }
    }
}

