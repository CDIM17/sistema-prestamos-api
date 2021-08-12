using Microsoft.AspNetCore.Mvc;
using sistema_prestamos_api.Models;
using sistema_prestamos_api.Services;
using Microsoft.Extensions.Configuration;

namespace sistema_prestamos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IConfiguration configuration, IPrestamoService prestamoService)
        {
            _configuration = configuration;
            _prestamoService = prestamoService;
        }



        [HttpGet("GetAllPrestamos")]
        public IActionResult GetAllPrestamos()
        {
            var data_prestamos = _prestamoService.GetallPrestamos();
            return Ok(data_prestamos);
        }


        [HttpPost("addPrestamo")]
        public IActionResult AddPrestamo(Prestamo prestamo)
        {
            if (prestamo is null) return NotFound();
            var filas_afectadas = _prestamoService.AddPrestamos(prestamo);
            return Ok(filas_afectadas);
        }
    }
}
