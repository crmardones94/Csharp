using Microsoft.Extensions.Logging;

namespace WebApiAutores.Middlwares
{
    public class loguearRespuestaHTTPMiddleware
    {
        private readonly RequestDelegate siguiente;
        private readonly ILogger<loguearRespuestaHTTPMiddleware> logger;

        public loguearRespuestaHTTPMiddleware(RequestDelegate siguiente, ILogger<loguearRespuestaHTTPMiddleware> logger)
        {
            this.siguiente = siguiente;
            this.logger = logger;
        }

        // invoke o invokeasync

        public async Task InvokeAsync(HttpContext contexto)
        {
            //todo lo que enviamos en el cuerpo se genera en el log

            using (var ms = new MemoryStream())
            {
                var cuerpooriginalrespuesta = contexto.Response.Body;
                contexto.Response.Body = ms;
                await siguiente(contexto);


                ms.Seek(0, SeekOrigin.Begin);
                string respuesta = new StreamReader(ms).ReadToEnd();
                ms.Seek(0, SeekOrigin.Begin);

                await ms.CopyToAsync(cuerpooriginalrespuesta);
                contexto.Response.Body = cuerpooriginalrespuesta;

                logger.LogInformation(respuesta);

            }
        }
    }
}
