using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;
using Import_Export_Company.Models;
using Import_Export_Company.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import_Export_Company.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Sku = p.Sku,
                Barcode = p.Barcode,
                Name = p.Name,
                Unit = p.Unit,
                Weight = p.Weight,
                Volume = p.Volume,
                Description = p.Description
            });
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new Exception("Product not found.");

            return new ProductDTO
            {
                Id = product.Id,
                Sku = product.Sku,
                Barcode = product.Barcode,
                Name = product.Name,
                Unit = product.Unit,
                Weight = product.Weight,
                Volume = product.Volume,
                Description = product.Description
            };
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO product)
        {
            var existingProduct = await _productRepository.GetBySkuAsync(product.Sku);
            if (existingProduct != null)
            {
                throw new Exception("Product with the same SKU already exists.");
            }

            var newProduct = new Products
            {
                Sku = product.Sku,
                Barcode = product.Barcode,
                Name = product.Name,
                Unit = product.Unit,
                Weight = product.Weight,
                Volume = product.Volume,
                Description = product.Description
            };

            await _productRepository.AddAsync(newProduct);
            await _productRepository.SaveChangesAsync();

            return new ProductDTO
            {
                Id = newProduct.Id,
                Sku = newProduct.Sku,
                Barcode = newProduct.Barcode,
                Name = newProduct.Name,
                Unit = newProduct.Unit,
                Weight = newProduct.Weight,
                Volume = newProduct.Volume,
                Description = newProduct.Description
            };
        }

        public async Task<ProductDTO> UpdateProductAsync(int id, CreateProductDTO product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found.");
            }

            if (existingProduct.Sku != product.Sku)
            {
                var productWithNewSku = await _productRepository.GetBySkuAsync(product.Sku);
                if (productWithNewSku != null) throw new Exception("Product with the same SKU already exists.");
            }

            existingProduct.Sku = product.Sku;
            existingProduct.Barcode = product.Barcode;
            existingProduct.Name = product.Name;
            existingProduct.Unit = product.Unit;
            existingProduct.Weight = product.Weight;
            existingProduct.Volume = product.Volume;
            existingProduct.Description = product.Description;

            _productRepository.UpdateAsync(existingProduct);
            await _productRepository.SaveChangesAsync();

            return new ProductDTO
            {
                Id = existingProduct.Id,
                Sku = existingProduct.Sku,
                Barcode = existingProduct.Barcode,
                Name = existingProduct.Name,
                Unit = existingProduct.Unit,
                Weight = existingProduct.Weight,
                Volume = existingProduct.Volume,
                Description = existingProduct.Description
            };
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            _productRepository.DeleteAsync(product);
            await _productRepository.SaveChangesAsync();
        }
    }
}