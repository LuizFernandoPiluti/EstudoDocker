
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EstudoDocker.WebApi.Exceptions
{
    public static class PessoaException
    {
        public static async Task<string> TrataExceptionAsync(Exception exception)
        {
            string msg = string.Empty;

            msg = exception.ToString(); 


            return msg;

        }
    }
}
