using ClienteService.Application.DTO;
using ClienteService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesAppService _clientesService;
        public ClientesController(IClientesAppService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteDto cliente)
        {
            var result = await _clientesService.CreateAsync(cliente);
            return StatusCode(201, result);
        }
    }
}
