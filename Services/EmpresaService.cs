using MySql.Data.MySqlClient;
using sistema_prestamos_api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_prestamos_api.Services
{
    public interface IEmpresaService
    {
        DataTable GetallEmpresa();
        int AddEmpresa(Empresa empresa);

        int UpdateEmpresa(Empresa empresa);

        int DeleteEmpresa(int id);
    }

    public class EmpresaService : IEmpresaService
    {
        private readonly AppDb _sqlDataSource;
        public EmpresaService(AppDb sqlDataSource)
        {
            _sqlDataSource = sqlDataSource;
        }

        public int AddEmpresa(Empresa empresa)
        {
            string query = @"insert into Empresa(RNC,Nombre, Telefono, Correo, Direccion)
            VALUES(@RNC,@Nombre,@Telefono,@Correo,@Direccion);";

            int filas_afectadas;

            using (MySqlConnection mycon = _sqlDataSource.Connection)
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@RNC", empresa.RNC);
                    myCommand.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                    myCommand.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                    myCommand.Parameters.AddWithValue("@Correo", empresa.Correo);
                    myCommand.Parameters.AddWithValue("@Direccion", empresa.Direccion);

                    filas_afectadas = myCommand.ExecuteNonQuery();

                    mycon.Close();
                }
            }
            return filas_afectadas;
        }

        public DataTable GetallEmpresa()
        {
            string query = @"SELECT * FROM Empresa";

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
        public int UpdateEmpresa(Empresa empresa)
        {
            string query = "UPDATE Empresa SET RNC = @RNC ,Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion WHERE Id = @Id";       

            int filas_afectadas;

            using (MySqlConnection mycon = _sqlDataSource.Connection)
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id", empresa.Id);
                    myCommand.Parameters.AddWithValue("@RNC", empresa.RNC);
                    myCommand.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                    myCommand.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                    myCommand.Parameters.AddWithValue("@Correo", empresa.Correo);
                    myCommand.Parameters.AddWithValue("@Direccion", empresa.Direccion);

                    filas_afectadas = myCommand.ExecuteNonQuery();

                    mycon.Close();
                }
            }
            return filas_afectadas;
        }

        public int DeleteEmpresa(int id)
        {
            string query = "DELETE FROM Empresa WHERE Id = @Id";

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
