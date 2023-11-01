using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Data.Dtos;

namespace StoreApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {

        private StoreContext _context;
        private IMapper _mapper;


        public StockController(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public List<ReadStockDto> GetAll()
        {
            var a = _mapper.Map<List<ReadStockDto>>(_context.Stocks.Include(x=> x.Product).ToList());

            return a;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if (stock is null) return NotFound();

            var stockDto = _mapper.Map<ReadStockDto>(stock);

            return Ok(stock);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateStockDto updateDto)
        {
            var update = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if (update is null) return NotFound();

            var result = _mapper.Map(updateDto, update);

            _context.SaveChanges();


            return Ok(result);
        }
    }
}
