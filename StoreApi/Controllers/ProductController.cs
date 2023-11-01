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


        [HttpGet]
        public List<ReadProdcutDto> GetAll()
        {
            return _mapper.Map<List<ReadProdcutDto>>(_context.Products.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product is null) return NotFound();

            return Ok(product);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProductDto filmeDto)
        {
            var prodAtt = _context.Products.FirstOrDefault(x=> x.Id == id);

            if(prodAtt is null) return NotFound();

            
            var result = _mapper.Map(filmeDto, prodAtt);

            _context.SaveChanges();


            return Ok(result);
        }
    }
}
