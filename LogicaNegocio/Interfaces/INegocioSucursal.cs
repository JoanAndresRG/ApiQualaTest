using Entidades.Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface INegocioSucursal
    {
        public Task<List<Sucursales>> ListarSucursales();
        public Task<Sucursales> SucursalPorCodigo(int codigo);
        public Task<int> CrearSucursal(Sucursales sucursal);
        public Task<int> ActualizarSucursa(Sucursales sucursal);
        public Task EliminarSucursal(int codigo);
    }
}
