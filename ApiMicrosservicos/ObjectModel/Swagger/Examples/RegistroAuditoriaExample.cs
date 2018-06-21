using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Api.ObjectModel.Swagger.Examples
{
    public class RegistroAuditoriaExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new RegistroAuditoria()
            {
                IsAuthenticated = true,
                Usuario = new UsuarioLogin
                {
                    Nome = "Teste auditoria inserção",
                    Email = "testeauditoriainserção@teste.com",
                    AuthTime = DateTime.Now
                },
                QueryString = "",
                BodyContent = "",
                CaminhoRequest = "v1/public/get"
            };
        }
    }
}
