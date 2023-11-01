using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Data;
using StoreApi.Data.Dtos;
using StoreApi.Models;

namespace StoreApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private StoreContext _context;
        private IMapper _mapper;


        public ProductController(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AddProduct(CreateProductDto productDto)
        {
            object prod;

            if (productDto is null)
            {
                throw new ApplicationException("For create a Product, must inform a Product in the parameter");
            }
            else
            {
                var productMap = _mapper.Map<Product>(productDto);

                _context.Products.Add(productMap);

                _context.SaveChanges();


                var productDb = _context.Products.FirstOrDefault(x => x.Id == productMap.Id);

                var stock = new Stock
                {
                    ProductId = productDb.Id,
                    Quantity = productDb.Quantity
                };

                _context.Stocks.Add(stock);

                _context.SaveChanges();


                prod = productMap;
            }

            return Ok(prod);
        }
    }
}
