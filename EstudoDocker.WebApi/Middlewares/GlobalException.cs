using EstudoDocker.WebApi.Exceptions;
using System.Net;

namespace EstudoDocker.WebApi.Middlewares
{
    public class GlobalException : IMiddleware
    {

        private readonly string _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") 
            ?? throw new ArgumentNullException("O ambiente deve ser informado");
        private readonly string _msgPadrão = "Houve um erro de processamento, informe o erro ao forcecedor";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

               await GlobalExceptionAsync(context, ex);
            }
           
            
        }

        public async Task GlobalExceptionAsync(HttpContext context, Exception exception)
        {
            if (context != null)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string msg = string.Empty;
                if (_env == "Development")
                {
                    msg = context.Request.Path.ToString() switch
                    {
                        "/api/Pessoa" => await PessoaException.TrataExceptionAsync(exception),
                        _ => throw new ArgumentNullException("Endpoint não localizado")
                    };


                }
                else
                {
                    msg =   _msgPadrão;
                }
             
    

                

                await context.Response.WriteAsJsonAsync(msg);
            }
            


        }
    }
}
