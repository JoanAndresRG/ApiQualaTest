using System.Net;

namespace Entidades.Entidades
{
    public class APIRespuesta
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public List<string> MensajeError { get; set; }
        public object Respuesta { get; set; }
    }
}
