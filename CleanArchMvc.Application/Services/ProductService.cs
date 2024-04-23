using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator )
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            //var productsEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            var productsQuery = new GetProductsQuery();
            if(productsQuery == null)
            {
                throw new Exception("Entity could not be loaded.");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        //public async Task<ProductDTO> GetBProductCategory(int? id)
        //{
        //    var productsEntity = await _productRepository.GetProductCategoryAsync(id);
        //    return _mapper.Map<ProductDTO>(productsEntity);
        //}

        //public async Task<ProductDTO> GetById(int? id)
        //{
        //    var productsEntity = await _productRepository.GetByIdAsync(id);
        //    return _mapper.Map<ProductDTO>(productsEntity);
        //}

        //public async Task Add(ProductDTO productDto)
        //{
        //    var productEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.CreateAsync(productEntity);
        //}

        //public async Task Update(ProductDTO productDto)
        //{
        //   var productEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.UpdateAsync(productEntity);
        //}
         
        //public async Task Remove(int? id)
        //{
        //    var productEntity = _productRepository.GetByIdAsync(id).Result;
        //    await _productRepository.RemoveAsync(productEntity);
        //}
    }
}
