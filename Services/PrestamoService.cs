using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using sistema_prestamos_api.Models;

namespace sistema_prestamos_api.Services
{
    public interface IPrestamoService
    {
        DataTable GetallPrestamos();
        int AddPrestamos(Prestamo prestamo);

        int UpdatePrestamo(Prestamo prestamo);

        int DeletePrestamo(int id);
    }
    public class PrestamoService : IPrestamoService
    {
        private readonly AppDb _sqlDataSource;
        public PrestamoService(AppDb sqlDataSource)
        {
            _sqlDataSource = sqlDataSource;
        }

        public int AddPrestamos(Prestamo prestamo)
        {
            string query = @"insert into Prestamo(ClienteId,UsuarioId, TipoPrestamoId, Monto, Cuota, Total, FechaInicio, FechaFin)
            VALUES(@ClienteId,@UsuarioId,@TipoPrestamoId,@Monto,@Cuota,@Total,@FechaInicio,@FechaFin);";

            int filas_afectadas;

            using (MySqlConnection mycon = _sqlDataSource.Connection)
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ClienteId", prestamo.ClienteId);
                    myCommand.Parameters.AddWithValue("@UsuarioId", prestamo.UsuarioId);
                    myCommand.Parameters.AddWithValue("@TipoPrestamoId", prestamo.TipoPrestamoId);
                    myCommand.Parameters.AddWithValue("@Monto", prestamo.Monto);
                    myCommand.Parameters.AddWithValue("@Cuota", prestamo.Cuota);
                    myCommand.Parameters.AddWithValue("@Total", prestamo.Total);
                    myCommand.Parameters.AddWithValue("@FechaInicio", prestamo.FechaInicio);
                    myCommand.Parameters.AddWithValue("@FechaFin", prestamo.FechaFin);

                    filas_afectadas = myCommand.ExecuteNonQuery();

                    mycon.Close();
                }
            }
            return filas_afectadas;
        }

        public DataTable GetallPrestamos()
        {
            string query = @"SELECT * FROM Prestamo";

            DataTable table = new DataTable();

            MySqlDataReader myReader;

            using (MySqlConnection mycon = _sqlDataSource.Connection)
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
        public int UpdatePrestamo(Prestamo prestamo)
        {
            string query = "UPDATE Prestamo SET ClienteId = @ClienteId,UsuarioId = @UsuarioId, TipoPrestamoId = @TipoPrestamoId, Monto = @Monto" +
                " , Cuota = @Cuota, Total = @Total, FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE Id = @Id";

            int filas_afectadas;

            using (MySqlConnection mycon = _sqlDataSource.Connection)
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id", prestamo.Id);
                    myCommand.Parameters.AddWithValue("@ClienteId", prestamo.ClienteId);
                    myCommand.Parameters.AddWithValue("@UsuarioId", prestamo.UsuarioId);
                    myCommand.Parameters.AddWithValue("@TipoPrestamoId", prestamo.TipoPrestamoId);
                    myCommand.Parameters.AddWithValue("@Monto", prestamo.Monto);
                    myCommand.Parameters.AddWithValue("@Cuota", prestamo.Cuota);
                    myCommand.Parameters.AddWithValue("@Total", prestamo.Total);
                    myCommand.Parameters.AddWithValue("@FechaInicio", prestamo.FechaInicio);
                    myCommand.Parameters.AddWithValue("@FechaFin", prestamo.FechaFin);

                    filas_afectadas = myCommand.ExecuteNonQuery();

                    mycon.Close();
                }
            }
            return filas_afectadas;
        }

        public int DeletePrestamo(int id)
        {
            string query = "DELETE FROM Prestamo WHERE Id = @Id";

            int filas_afectadas;

            using (MySqlConnection mycon = _sqlDataSource.Connection)
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
