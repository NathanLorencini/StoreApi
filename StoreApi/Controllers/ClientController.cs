using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Data;
using StoreApi.Data.Dtos;
using StoreApi.Models;

namespace StoreApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private StoreContext _context;
        private IMapper _mapper;

        public ClientController(IMapper mapper, StoreContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpPost]
        public IActionResult AddClinet(CreateClientDto clientDto)
        {

            object clientResult;

            if (clientDto is null)
            {
                throw new ApplicationException("For create a Client, must inform a Client in the parameter");

            }
            else
            {
                var client = _mapper.Map<Client>(clientDto);

                _context.Clients.Add(client);

                _context.SaveChanges();

                clientResult = client;
            }
            
            return Ok(clientResult);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var clienteById = _context.Clients.FirstOrDefault(x=> x.Id == id);

            if (clienteById is null) return NotFound();

            var client = _mapper.Map<ReadClientDto>(clienteById);

            return Ok(client);
        }

        [HttpGet]
        public List<ReadClientDto> GetAll()
        {
            return _mapper.Map<List<ReadClientDto>>(_context.Clients.ToList());
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateClientDto clientDto)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Id == id);

            if (client is null) return NotFound();

            
            var result = _mapper.Map(clientDto, client);

            
            _context.SaveChanges();

            return Ok(result);
        }
    }
}
