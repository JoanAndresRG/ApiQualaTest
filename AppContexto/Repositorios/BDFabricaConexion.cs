using AppContexto.Intefaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AppContexto.Repositorios
{
    public class BDFabricaConexion : IBDFabricaConexion
    {
        private readonly string _conexion;
        public BDFabricaConexion(IConfiguration configuracion )
        {
            _conexion = configuracion.GetConnectionString("conexionDB");
        }

        public SqlConnection CrearConexion()
        {
            var conexion = new SqlConnection( _conexion );
            conexion.Open();
            return conexion;
        }
    }
}
