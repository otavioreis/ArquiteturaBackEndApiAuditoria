using Livraria.Api.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Api.Repository.Interface
{
    public interface IAuditoriaRepository
    {
        Task<List<RegistroAuditoria>> GetRegistrosAuditoriaAsync();
        Task<string> InserirRegistroAuditoriaAsync(RegistroAuditoria registroAuditoria);


    }
}
