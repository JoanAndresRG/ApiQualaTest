using AppContexto.Intefaces;
using Entidades.Entidades;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Negocio
{
    public class NegocioSucursal : INegocioSucursal
    {
        private readonly IRepositorioSucursal _repositorioSucursal;
        public NegocioSucursal(IRepositorioSucursal repositorioSucursal)
        {
            _repositorioSucursal = repositorioSucursal;
        }

        public async Task<List<Sucursales>> ListarSucursales()
        {
            return await _repositorioSucursal.ListarSucursales();
        }
        public async Task<Sucursales> SucursalPorCodigo(int codigo)
        {
            return await _repositorioSucursal.SucursalPorCodigo(codigo);
        }
        public async Task<int> CrearSucursal(Sucursales sucursal)
        {
            return await _repositorioSucursal.CrearSucursal(sucursal);
        }
        public async Task<int> ActualizarSucursa(Sucursales sucursal)
        {
            return await _repositorioSucursal.ActualizarSucursa(sucursal);
        }

        public async Task EliminarSucursal(int codigo)
        {
            await _repositorioSucursal.EliminarSucursal(codigo);
        }

    }
}
