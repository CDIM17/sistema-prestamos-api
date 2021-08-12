using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using sistema_prestamos_api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_prestamos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPrestamoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TipoPrestamoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllTipoPrestamos()
        {
            string sqlDataSource = _configuration.GetConnectionString("PrestamoAppCon");

            TipoPrestamo tp = new TipoPrestamo();
            DataTable data_tipo_prestamos = tp.Retornar_Datos_Tipo_Prestamos(sqlDataSource);

            return Ok(data_tipo_prestamos);
        }

        [HttpPost]
        public IActionResult AddTipoPrestamos(TipoPrestamo tp)
        {
            string sqlDataSource = _configuration.GetConnectionString("PrestamoAppCon");
            int filas_afectadas = tp.Guardar_Tipo_Prestamo(sqlDataSource, tp);
            return Ok("Inserted Succesfully");
        }

        [HttpPut]
        public IActionResult UpdateTipoPrestamo(TipoPrestamo tp)
        {
            string sqlDataSource = _configuration.GetConnectionString("PrestamoAppCon");
            int filas_afectadas = tp.Actualizar_Tipo_Prestamo(sqlDataSource, tp);
            return Ok("Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTipoPrestamo(int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("PrestamoAppCon");
            TipoPrestamo tp = new TipoPrestamo();
            int filas_afectadas = tp.Eliminar_Tipo_Prestamo(sqlDataSource, id);
            return Ok("Deleted Succesfully");
        }

    }
}
