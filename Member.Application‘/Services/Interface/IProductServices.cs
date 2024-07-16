using System;
using Member.Domain.DTOs;

namespace Member.Application_.Services.Interface
{
	public interface IProductServices
	{
        List<ProductResponse> GetProducts();

        List<ProductResponse> ProductsWithQuantityGreaterThanFive();

        ProductResponse GetProductById(int productId);

        void DeleteProductById(int productId);

        ProductResponse CreateProduct(CreateProductRequest request);

        ProductResponse UpdateProduct(int productId, UpdateProductRequest request);
    }
}

