using Entidades.Entidades;

namespace AppContexto.Intefaces
{
    public interface IRepositorioSucursal
    {
        public Task<List<Sucursales>> ListarSucursales();
        public Task<Sucursales> SucursalPorCodigo(int codigo);
        public Task<int> CrearSucursal(Sucursales sucursal);
        public Task<int> ActualizarSucursa(Sucursales sucursal);
        public Task EliminarSucursal(int codigo);

    }
}
