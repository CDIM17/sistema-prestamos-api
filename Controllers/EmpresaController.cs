using Microsoft.AspNetCore.Mvc;
using sistema_prestamos_api.Models;
using sistema_prestamos_api.Services;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace sistema_prestamos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IConfiguration configuration, IEmpresaService empresaService)
        {
            _configuration = configuration;
            _empresaService = empresaService;
        }
        [HttpGet("GetAllEmpresas")]
        public IActionResult GetAllEmpresas()
        {
            DataTable empresas = _empresaService.GetallEmpresa();
            return Ok(empresas);
        }

        [HttpPost("addEmpresa")]
        public IActionResult AddingEmpresa(Empresa empresa)
        {
            if (empresa is null) return NotFound();
            var filas_afectadas = _empresaService.AddEmpresa(empresa);
            return Ok(filas_afectadas);
        }
        [HttpPut]
        public IActionResult UpdateEmpresa(Empresa empresa)
        {
            int filas_afectadas = _empresaService.UpdateEmpresa(empresa);
            return Ok("Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmpresa(int id)
        {
            int filas_afectadas = _empresaService.DeleteEmpresa(id);
            return Ok("Deleted Succesfully");
        }
    }
}
