using System.Data.SqlClient;

namespace AppContexto.Intefaces
{
    public interface IBDFabricaConexion
    {
        public SqlConnection CrearConexion(); 
    }
}
