using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Api.ObjectModel;
using Livraria.Api.Repository.Interface;

namespace Livraria.Api.Repository
{
    public class AuditoriaRepository : IAuditoriaRepository
    {
        private readonly Lazy<List<RegistroAuditoria>> _registrosAuditoriaLazy;

        public AuditoriaRepository()
        {
            _registrosAuditoriaLazy = new Lazy<List<RegistroAuditoria>>(PopularAuditoriaMock());
        }

        public List<RegistroAuditoria> RegistrosAuditoriaMock
        {
            get { return _registrosAuditoriaLazy.Value; }
        }


        public async Task<List<RegistroAuditoria>> GetRegistrosAuditoriaAsync()
        {
            return await Task.Run(() => RegistrosAuditoriaMock);
        }

        public async Task<string> InserirRegistroAuditoriaAsync(RegistroAuditoria registroAuditoria)
        {
            RegistrosAuditoriaMock.Add(registroAuditoria);

            return await Task.Run(() => "Registro inserido com sucesso na auditoria");
        }

        private List<RegistroAuditoria> PopularAuditoriaMock()
        {
            return new List<RegistroAuditoria>()
            {
                new RegistroAuditoria()
                {
                    IsAuthenticated = true,
                    Usuario = new UsuarioLogin
                    {
                        Nome = "Teste auditoria 1",
                        Email = "testeauditoria@teste.com",
                        AuthTime = DateTime.Now
                    },
                    QueryString = "",
                    BodyContent = "",
                    CaminhoRequest = "v1/public/get"
                },
                new RegistroAuditoria()
                {
                    IsAuthenticated = true,
                    Usuario = new UsuarioLogin
                    {
                        Nome = "Teste auditoria 2",
                        Email = "testeauditoria22@teste.com",
                        AuthTime = DateTime.Now.AddDays(-2)
                    },
                    QueryString = "",
                    BodyContent = "",
                    CaminhoRequest = "v1/private/getTeste"
                }
            };
        }

        
    }
}
