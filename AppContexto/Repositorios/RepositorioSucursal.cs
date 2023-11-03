using AppContexto.Intefaces;
using Dapper;
using Entidades.Entidades;
using System.Data;

namespace AppContexto.Repositorios
{
    public class RepositorioSucursal : IRepositorioSucursal
    {
        private readonly IBDFabricaConexion _bdFabricaConexion;
        public RepositorioSucursal(IBDFabricaConexion bDFabricaConexion)
        {
            _bdFabricaConexion = bDFabricaConexion;
        }

        public async Task<List<Sucursales>> ListarSucursales()
        {
            using (var conexion = _bdFabricaConexion.CrearConexion())
            {
                try
                {
                    string pa_listar_sucursales = "PA_LISTAR_SUCURSALES";
                    List<Sucursales> sucursales = (await conexion.QueryAsync<Sucursales>(pa_listar_sucursales, commandType: CommandType.StoredProcedure)).ToList();
                    return sucursales;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public async Task<Sucursales> SucursalPorCodigo(int codigo)
        {
            using (var conexion = _bdFabricaConexion.CrearConexion())
            {
                try
                {
                    string pa_sucursal_por_codigo = "PA_BUSCAR_SUCURSAL_POR_CODIGO";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Codigo", codigo, DbType.Int32, ParameterDirection.Input);
                    Sucursales sucursal = await conexion.QuerySingleAsync<Sucursales>(pa_sucursal_por_codigo, parameters, commandType: CommandType.StoredProcedure);
                    return sucursal;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Conexion: {ex.Message}");
                }
                finally
                {
                    conexion.Close();
                }


            }
        }

        public async Task<int> CrearSucursal(Sucursales sucursal)
        {
            using (var conexion = _bdFabricaConexion.CrearConexion())
            {
                try
                {
                    string pa_listar_sucursales = "PA_CREAR_SUSCURSAL";
                    var parametros = new DynamicParameters();
                    parametros.Add("@Nombre", sucursal.Nombre, DbType.String, ParameterDirection.Input);
                    parametros.Add("@Descripcion", sucursal.Descripcion, DbType.String, ParameterDirection.Input);
                    parametros.Add("@Direccion", sucursal.Direccion, DbType.String, ParameterDirection.Input);
                    parametros.Add("@Identificacion", sucursal.Identificacion, DbType.String, ParameterDirection.Input);
                    parametros.Add("@FechaCreacion", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
                    parametros.Add("@IdMoneda", sucursal.IdMoneda, DbType.Int32, ParameterDirection.Input);
                    var codigo = await conexion.QueryFirstOrDefaultAsync<int>(pa_listar_sucursales, parametros, commandType: CommandType.StoredProcedure);
                    return codigo;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }

            }
        }

        public async Task<int> ActualizarSucursa(Sucursales sucursal)
        {
            using (var conexion = _bdFabricaConexion.CrearConexion())
            {
                try
                {
                    string pa_actualizar_sucursal = "PA_ACTUALIZAR_SUCURSAL";
                    var parametros = new DynamicParameters();
                    parametros.Add("@Codigo", sucursal.Codigo, DbType.Int32, ParameterDirection.Input);
                    parametros.Add("@Nombre", sucursal.Nombre, DbType.String, ParameterDirection.Input);
                    parametros.Add("@Descripcion", sucursal.Descripcion, DbType.String, ParameterDirection.Input);
                    parametros.Add("@Direccion", sucursal.Direccion, DbType.String, ParameterDirection.Input);
                    parametros.Add("@Identificacion", sucursal.Identificacion, DbType.String, ParameterDirection.Input);
                    parametros.Add("@FechaCreacion", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
                    parametros.Add("@IdMoneda", sucursal.IdMoneda, DbType.Int32, ParameterDirection.Input);
                    await conexion.ExecuteAsync(pa_actualizar_sucursal, parametros, commandType: CommandType.StoredProcedure);
                    return sucursal.Codigo;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
        public async Task EliminarSucursal(int codigo)
        {
            using (var conexion = _bdFabricaConexion.CrearConexion())
            {
                try
                {
                    string pa_eliminar_por_codigo = "PA_ELIMINAR_SUCURSAL";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Codigo", codigo, DbType.Int32, ParameterDirection.Input);
                    await conexion.ExecuteAsync(pa_eliminar_por_codigo, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally { conexion.Close(); }
            }
        }
    }
}
