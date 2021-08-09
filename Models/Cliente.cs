using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_prestamos_api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre {get; set;}
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        public DataTable Retornar_Datos_Clientes(string sqlDataSource)
        {
            string query = @"SELECT * FROM Cliente";

            DataTable table = new DataTable();

            MySqlDataReader myReader;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return table;
        }

        public int Guardar_Datos_Clientes(string sqlDataSource,Cliente cli)
        {
            string query = @"insert into Cliente(Cedula,Nombre, Apellido, Telefono, Correo,Direccion)
VALUES(@Cedula,@Nombre,@Apellido,@Telefono,@Correo,@Direccion);";

            int filas_afectadas;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Cedula", cli.Cedula);
                    myCommand.Parameters.AddWithValue("@Nombre", cli.Nombre);
                    myCommand.Parameters.AddWithValue("@Apellido", cli.Apellido);
                    myCommand.Parameters.AddWithValue("@Telefono", cli.Telefono);
                    myCommand.Parameters.AddWithValue("@Correo", cli.Correo);
                    myCommand.Parameters.AddWithValue("@Direccion", cli.Direccion);

                    filas_afectadas = myCommand.ExecuteNonQuery();

                    mycon.Close();
                }
            }

            return filas_afectadas;
        }


    }
}
