using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace sistema_prestamos_api.Models
{
    public class TipoPrestamo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int TasaInteres { get; set; }

        public DataTable Retornar_Datos_Tipo_Prestamos(string sqlDataSource)
        {
            string query = @"SELECT * FROM TipoPrestamo";

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

        public int Guardar_Tipo_Prestamo(string sqlDataSource, TipoPrestamo tp)
        {
            string query = @"insert into TipoPrestamo(Descripcion,TasaInteres)
            VALUES(@Descripcion,@TasaInteres);";

            int filas_afectadas;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Descripcion", tp.Descripcion);
                    myCommand.Parameters.AddWithValue("@TasaInteres", tp.TasaInteres);
                    
                    filas_afectadas = myCommand.ExecuteNonQuery();

                    mycon.Close();
                }
            }
            return filas_afectadas;
        }

        public int Actualizar_Tipo_Prestamo(string sqlDataSource, TipoPrestamo tp)
        {
            string query = "UPDATE TipoPrestamo SET Descripcion = @Descripcion, TasaInteres = @TasaInteres  WHERE Id = @Id";

            int filas_afectadas;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id", tp.Id);
                    myCommand.Parameters.AddWithValue("@Descripcion", tp.Descripcion);
                    myCommand.Parameters.AddWithValue("@TasaInteres", tp.TasaInteres);
                    
                    filas_afectadas = myCommand.ExecuteNonQuery();

                    mycon.Close();
                }
            }
            return filas_afectadas;
        }

        public int Eliminar_Tipo_Prestamo(string sqlDataSource, int id)
        {
            string query = "DELETE FROM TipoPrestamo WHERE Id = @Id";

            int filas_afectadas;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);

                    filas_afectadas = myCommand.ExecuteNonQuery();

                    mycon.Close();
                }
            }
            return filas_afectadas;
        }


    }
}
