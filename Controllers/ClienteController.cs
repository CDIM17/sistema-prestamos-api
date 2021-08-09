﻿using Microsoft.AspNetCore.Http;
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
    public class ClienteController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Getallclientes()
        {
            string sqlDataSource = _configuration.GetConnectionString("PrestamoAppCon");

            Cliente cli = new Cliente();
            DataTable data_employee = cli.Retornar_Datos_Clientes(sqlDataSource);

            return Ok(data_employee);
        }

        [HttpPost("addcliente")]
        public IActionResult AddCliente(Cliente cli)
        {
            string sqlDataSource = _configuration.GetConnectionString("PrestamoAppCon");
            int filas_afectadas = cli.Guardar_Datos_Clientes(sqlDataSource,cli);

            return Ok("Inserted Succesfully");
        }

    }
}
