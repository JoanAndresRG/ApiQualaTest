using AutoMapper;
using Entidades.DTDs;
using Entidades.Entidades;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace apiQualaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly INegocioSucursal _negocioSucursal;
        private readonly IMapper _mapper;
        protected APIRespuesta _aPIRespuesta;
        public SucursalController(INegocioSucursal negocioSucursal, IMapper mapper)
        {
            _negocioSucursal = negocioSucursal;
            _aPIRespuesta = new();
            _mapper = mapper;
        }

        [HttpGet("ListarSucursales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIRespuesta>> ListarSucursales()
        {
            try
            {
                List<Sucursales> sucursales = await _negocioSucursal.ListarSucursales();
                if (sucursales == null)
                {
                    _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                    _aPIRespuesta.IsSuccessful = false;
                    _aPIRespuesta.MensajeError = new List<string> { "BD no retorno data" };
                    return BadRequest(_aPIRespuesta);
                }
                List<SucursalDTO> sucursalDTOs = _mapper.Map<List<SucursalDTO>>(sucursales);
                _aPIRespuesta.StatusCode = HttpStatusCode.OK;
                _aPIRespuesta.IsSuccessful = true;
                _aPIRespuesta.Respuesta = sucursalDTOs;
                return Ok(_aPIRespuesta);
            }
            catch (Exception ex)
            {
                _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                _aPIRespuesta.IsSuccessful = false;
                _aPIRespuesta.MensajeError = new List<string>() { ex.ToString() };
                return BadRequest(_aPIRespuesta);
            }
        }

        [HttpGet("Sucursal/{codigo:int}", Name = "SucursalesPorCodigo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIRespuesta>> SucursalesPorCodigo([FromRoute] int codigo)
        {
            try
            {
                if (codigo == 0)
                {
                    _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                    _aPIRespuesta.IsSuccessful = false;
                    _aPIRespuesta.MensajeError = new List<string> { "Parametro codigo requerido" };
                    return BadRequest(_aPIRespuesta);
                }
                Sucursales sucursal = await _negocioSucursal.SucursalPorCodigo(codigo);
                if (sucursal == null)
                {
                    _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                    _aPIRespuesta.IsSuccessful = false;
                    _aPIRespuesta.MensajeError = new List<string> { "BD no retorno data" };
                    return BadRequest(_aPIRespuesta);
                }
                SucursalDTO sucursalDTO = _mapper.Map<SucursalDTO>(sucursal);
                _aPIRespuesta.StatusCode = HttpStatusCode.OK;
                _aPIRespuesta.IsSuccessful = true;
                _aPIRespuesta.Respuesta = sucursalDTO;
                return Ok(_aPIRespuesta);
            }
            catch (Exception ex)
            {
                _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                _aPIRespuesta.IsSuccessful = false;
                _aPIRespuesta.MensajeError = new List<string>() { ex.ToString() };
                return BadRequest(_aPIRespuesta);
            }
        }

        [HttpPost("CrearSucursal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIRespuesta>> CrearSucursal([FromBody] SucursalInsertarDTO insertarDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                    _aPIRespuesta.IsSuccessful = false;
                    _aPIRespuesta.MensajeError = new List<string> { "Todos los parametros son obligatorios" };
                    return BadRequest(_aPIRespuesta);
                }
                Sucursales sucursal = _mapper.Map<Sucursales>(insertarDTO);
                int respuesta = await _negocioSucursal.CrearSucursal(sucursal);
                if (respuesta == 0)
                {
                    _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                    _aPIRespuesta.IsSuccessful = false;
                    _aPIRespuesta.MensajeError = new List<string> { "BD no retorno data" };
                    return BadRequest(_aPIRespuesta);
                }
                _aPIRespuesta.StatusCode = HttpStatusCode.Created;
                _aPIRespuesta.IsSuccessful = true;
                _aPIRespuesta.Respuesta = insertarDTO;
                return CreatedAtRoute("SucursalesPorCodigo", new { codigo = respuesta }, _aPIRespuesta);

            }
            catch (Exception ex)
            {
                _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                _aPIRespuesta.IsSuccessful = false;
                _aPIRespuesta.MensajeError = new List<string>() { ex.ToString() };
                return BadRequest(_aPIRespuesta);
            }
        }

        [HttpPost("ActualizarSucursal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIRespuesta>> ActualizarSucursal([FromBody] SucursalInsertarDTO insertarDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                    _aPIRespuesta.IsSuccessful = false;
                    _aPIRespuesta.MensajeError = new List<string> { "Todos los parametros son obligatorios" };
                    return BadRequest(_aPIRespuesta);
                }
                Sucursales sucursal = _mapper.Map<Sucursales>(insertarDTO);
                int respuesta = await _negocioSucursal.ActualizarSucursa(sucursal);
                if (respuesta == 0)
                {
                    _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                    _aPIRespuesta.IsSuccessful = false;
                    _aPIRespuesta.MensajeError = new List<string> { "BD no retorno data" };
                    return BadRequest(_aPIRespuesta);
                }
                _aPIRespuesta.StatusCode = HttpStatusCode.Created;
                _aPIRespuesta.IsSuccessful = true;
                _aPIRespuesta.Respuesta = insertarDTO;
                return CreatedAtRoute("SucursalesPorCodigo", new { codigo = respuesta }, _aPIRespuesta);
            }
            catch (Exception ex)
            {
                _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                _aPIRespuesta.IsSuccessful = false;
                _aPIRespuesta.MensajeError = new List<string>() { ex.ToString() };
                return BadRequest(_aPIRespuesta);
            }
        }

        [HttpGet("EliminarSucursal/{codigo:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIRespuesta>> EliminarSucursal([FromRoute] int codigo)
        {
            try
            {
                if (codigo == 0)
                {
                    _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                    _aPIRespuesta.IsSuccessful = false;
                    _aPIRespuesta.MensajeError = new List<string> { "Parametro codigo requerido" };
                    return BadRequest(_aPIRespuesta);
                }
                await _negocioSucursal.EliminarSucursal(codigo);
                _aPIRespuesta.StatusCode = HttpStatusCode.OK;
                _aPIRespuesta.IsSuccessful = true;
                return Ok(_aPIRespuesta);
            }
            catch (Exception ex)
            {
                _aPIRespuesta.StatusCode = HttpStatusCode.BadRequest;
                _aPIRespuesta.IsSuccessful = false;
                _aPIRespuesta.MensajeError = new List<string>() { ex.ToString() };
                return BadRequest(_aPIRespuesta);
            }
        }
    }
}

